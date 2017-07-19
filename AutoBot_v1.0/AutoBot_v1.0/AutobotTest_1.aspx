<%@ Page Title="" Language="C#" MasterPageFile="~/BasicPage.Master" AutoEventWireup="true" CodeBehind="AutobotTest_1.aspx.cs" Inherits="AutoBot_v1._0.AutobotTest_1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="Scripts/platform.js"></script>
    <script src="Scripts/webspeech.js"></script>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/ActionScript.js"></script>


    <div class="container">
        <form id="form1">
            <div class="row">
                <div class="col-md-12">
                    <center style="height: 40px">
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <h4><b>A</b>utomated <b>R</b>eplying <b>M</b>achine</h4>
                        </div>
                    </div>
                </center>
                    <hr />

                    <ul class="nav nav-tabs" id="myTab">
                        <li class="active"><a data-target="#manual" href="#manual" data-toggle="tab">Manual Action</a></li>
                        <li><a data-target="#machine" href="#machine" data-toggle="tab">Voice Action</a></li>
                    </ul>

                    <div class="tab-content" style="padding: 10px">
                        <div class="tab-pane active" style="margin-bottom: 10px;" id="manual">
                            <div class="row">
                                <div class="col-md-8 text-center">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <span class="control-label pull-right">User Action</span>
                                            </div>
                                            <div class="col-md-8">
                                                <input type="text" class="form-control userAction" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <span class="control-label pull-right">&nbsp;</span>
                                            </div>
                                            <div class="col-md-8 pull-left">
                                                <input type="button" onclick="ManualTest()" value="Push Command" class="btn btn-success" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <span class="control-label pull-right">Machine Response</span>
                                            </div>
                                            <div class="col-md-8">
                                                <span style="width: 100%; height: 100px; border: 1px solid #ccc; display: block; border-radius: 4px;" class="machineResponse">&nbsp;</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane" style="margin-bottom: 10px;" id="machine">
                            <div class="row">
                                <div class="col-md-8">
                                    Click the below button to recoginize your voice by the machine....
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 pull-left ">
                                    <input type="button" onclick="VoiceCommand()" value="Voice Command" class="btn btn-success" />
                                </div>
                            </div>
                        </div>
                    </div>



                </div>
            </div>
        </form>
    </div>



</asp:Content>
