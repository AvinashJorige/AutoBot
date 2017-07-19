var speaker, listener;
var recognizer = new webkitSpeechRecognition();
var question = "";
var staticConfig = {};

$(document).ready(function () {
    $.ajax({
        url: 'config/MachineConfig.json',
        dataType: 'json',
        success: function (data) {
            staticConfig.config = data;
        },
        statusCode: {
            404: function () {
                alert('There was a problem with the server.  Try again soon!');
            }
        }
    });
});

function VoiceCommand() {
    try {

        InitializeWebSpeech();
        fncRecognizer()
        initialCalls();
        
        listener.listen("en", function (text) {
            activeActions("voice", text);
        });
        
    } catch (e) {
        console.log("Voice Command | Error | ", e);
    }

}

function ManualTest() {
    try {
        var text = $(".userAction").val();
        activeActions("manual", text);
    } catch (e) {
        console.log("ManualTest | Error | ", e);
    }
}


function activeActions(modeType, text) {
    try {
        var obj = {};
        var validEntry = false;
            var flag = false;
            var SaveList = [];
            staticConfig.config.PredefinedIndexes.find(function (d) {
                if (text.indexOf(d.index) > -1) {
                    //responseMachine(Indexes, actions, returnValue, modeType)                    
                    responseMachine(null, null, d.action, modeType);
                    flag = true;
                }
            });
            staticConfig.config.SaveList.find(function (d) {
                if ((text.toLowerCase()).indexOf(d) == 0) {
                    dd = (text.toLowerCase()).split(d);
                    validEntry = true;
                }
            });

            staticConfig.config.talkBack.find(function (d) {
                if ((text.toLowerCase()).indexOf(d) > -1) {
                    responseMachine(null, null, d.action, modeType);
                    flag = true;
                    validEntry = true;
                }
            });

            if (!flag) {
                if (validEntry) {
                    var response = {};
                    response.ActionResponse = dd[1];
                    response.Indexes = question;
                    obj.response = response;
                    clientToServerCall(
                       "AutobotTest_1.aspx/UserActionSave", // URL
                       obj,                         // Input Data   
                       "POST",                        // Service call type
                       modeType
                    );
                }
                else {
                    obj.intakeContent = text;
                    clientToServerCall(
                       "AutobotTest_1.aspx/ActionInTake", // URL
                       obj,                         // Input Data   
                       "POST",                        // Service call type
                       modeType
                   );
                }
            }
    } catch (e) {
        console.log("activeActions|ERROR : ", e);
    }
}

function initialCalls(invite) {
    try {
        if (!invite) {
            talk(speaker, "Welcome to Auto talk back program. Feel free to talk with me.");
        }

    } catch (e) {
        console.log("initialCalls|ERROR : ", e);
    }
}


function fncRecognizer() {
    try {
        // Voice recognizer initiallzing in the browser to capture the user voice  
        // NOTE : Currently supported by Google Chrome browser only.

        recognizer.lang = "en";
        recognizer.onresult = function (event) {
            if (event.results.length > 0) {
                var result = event.results[event.results.length - 1];
                if (result.isFinal) {
                    console.log(result[0].transcript);
                    var text = result[0].transcript.toLowerCase();
                    activeActions("voice", text);

                }
            }
        };
        console.log("recognizer starts");
        recognizer.start();
    } catch (e) {
        console.log("recognizer Error : ", e);
    }
}

function InitializeWebSpeech() {
    try {
        ws = webSpeechNoConflict();
        try {
            speaker = new ws.Speaker();
            speaker.onEnd(function () {
                fncRecognizer();
                InitializeWebSpeech()
            });
        }
        catch (ex) {
            console.log(ex);
            speaker = null;
            // document.getElementById("status").innerHTML = ex;
        }
        try {
            listener = new ws.Listener();
        }
        catch (ex) {
            console.log(ex);
            listener = null;
            //document.getElementById("status").innerHTML = ex;
        }
    } catch (e) {
        console.log("InitialWebSpeech Error : ", e)
    }
}

/// function to talk bacck to the user
function talk(speaker, value) {
    // speaker.speak("en", document.getElementById("text").value);
    speaker.speak("en", value);
}



// Function : clientToServerCall
// Desc : Client to server web api RESTFull Call
// Params : URL, Data, RESTfull service call type 
function clientToServerCall(url, dataToSend, dataType, modeType) {
    try {
        $.ajax({
            url: url,
            type: 'POST',
            async: false,
            dataType: 'json',
            data: JSON.stringify(dataToSend),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                //responseMachine(Indexes, actions, returnValue, modeType)
                var obj = {};
                if (data.d.message == "fails" && data.d.status == 400) {
                    responseMachine(data.d.value.Indexes, "", data.d.value.returnValue, modeType);
                }
                else {
                    obj.actionRes = data.d.value.returnValue;
                    if (modeType == "voice")
                        talk(speaker, obj.actionRes);
                    else {
                        $(".userAction").val("");
                        $(".machineResponse").html(obj.actionRes)
                    }
                    responseMachine("", "", data.d.value.returnValue, modeType);
                }
                if (modeType == "voice")
                    initialCalls(true);
            },
            error: function (e, x, settings, exception) {
                var message;
                var statusErrorMap = {
                    '400': "Server understood the request, but request content was invalid.",
                    '401': "Unauthorized access.",
                    '403': "Forbidden resource can't be accessed.",
                    '500': "Internal server error.",
                    '503': "Service unavailable."
                };
                if (x.status) {
                    message = statusErrorMap[x.status];
                    if (!message) {
                        message = "Unknown Error \n.";
                    }
                } else if (exception == 'parsererror') {
                    message = "Error.\nParsing JSON Request failed.";
                } else if (exception == 'timeout') {
                    message = "Request Time out.";
                } else if (exception == 'abort') {
                    message = "Request was aborted by the server";
                } else {
                    message = "Unknown Error \n.";
                }
                console.log("Serivce Call Error : ", message);
                fncRecognizer();
                InitializeWebSpeech();
            }
        });
    } catch (e) {
        console.log("Try Catch Error : ", e);
    }
}

function responseMachine(Indexes, actions, returnValue, modeType) {
    try {
        var errorValue = "";
        if (returnValue)
            errorValue = returnValue;
        if (Indexes)
            question = Indexes;
        if (modeType == "voice")
            talk(speaker, errorValue);
        else {
            $(".userAction").val("");
            $(".machineResponse").html(errorValue)
        }
        if (modeType == "voice")
            initialCalls(true);
    } catch (e) {
        console.log("ResponseMachine | ERROR : ", e);
    }
}