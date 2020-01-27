<%@ Page Language="VB" 
         MasterPageFile="~/gHeader.master" 
         CodeFile="Default.aspx.vb" 
         Inherits="Login" 
         Theme="gThemes"  %>
<%@ Import Namespace="genius" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" border="0" cellspacing="0" cellpadding="0"> 
	<tr>
	    <td align="center" valign="middle" style="height: 420px">
            <table width="400" height="150" border="1" cellpadding="1" cellspacing="0" bordercolor="#006699" class="borderthick">
	            <tr>
	                <td align="center" valign="top" style="height: 150px">
	                    <table width="100%" border="0" cellspacing="2" cellpadding="3">
				            <tr>
					            <td height="25" align="left" class="bgcolor1" style="width: 393px">
						            <table width="100%" border="0" cellspacing="0" cellpadding="0">
							            <tr>
								            <td width="4%" height="19">&nbsp;                       </td>
									        <td width="96%" class="subheading" height="19">Login    </td>
							            </tr>
							        </table>
						        </td>
					        </tr>
					        <tr>
		                        <td height="25" align="center" valign="middle" class="bgcolor2" style="width: 393px">
		                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
					                    <tr>
							                <td width="30%" align="left">&nbsp;User Name<font color="red">*</font></td>
							                <td align="left" style="width: 190px">
							                    <asp:TextBox 
							                        ID="txtUserName" 
							                        TabIndex="1"
							                        runat="server" 
							                        CssClass="sform" 
							                        Width="125px">
							                    </asp:TextBox>
							                    <asp:RequiredFieldValidator 
							                        id="RequiredFieldtxtUserName" 
							                        ErrorMessage="Please Enter User Name"
								                    ControlToValidate="txtUserName" 
								                    Text="*"
								                    runat="server" 
								                    SetFocusOnError="True" />
						                    </td>
						                    <td align="left" style="width: 150px">
                                                <asp:LinkButton 
                                                    ID="LinkChangePwrd" 
                                                    runat="server" 
                                                    CausesValidation="False"
                                                    PostBackUrl="~/ChangePassWord.aspx"
                                                    TabIndex="7">Change Password
                                                </asp:LinkButton>
                                             </td>
						                </tr>
						            </table>
				                </td>
				            <tr>
		                        <td height="25" align="center" valign="middle" class="bgcolor2" style="width: 393px">
		                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
					                    <tr>
						                    <td width="30%" align="left">&nbsp;Password<font color="red">*</font></td>
							                <td align="left" style="width: 190px">
							                    <asp:TextBox 
							                        ID="txtPassword"
							                        TabIndex="2" 
							                        runat="server" 
							                        CssClass="sform" 
							                        Width="125px" 
							                        TextMode="Password">
							                    </asp:TextBox>
							                    <asp:RequiredFieldValidator 
							                        id="RequiredFieldtxtPassword" 
							                        ErrorMessage="Please Enter Password"
								                    ControlToValidate="txtPassword" 
								                    Text="*"
								                    runat="server" 
								                    SetFocusOnError="True" />&nbsp;
								             </td> 
								             <td align="left" style="width: 150px">
                                                <asp:LinkButton 
                                                    ID="LinkPwrdRequest" 
                                                    TabIndex="8"
                                                    CausesValidation="False"                                                    
                                                    PostBackUrl="~/PassWordRequest.aspx"
                                                    runat="server">Password Request
                                                </asp:LinkButton>
                                            </td>
						                </tr>
						            </table>
				                </td>
				            </tr>   
		                    <tr>
		                        <td height="25" align="center" valign="middle" class="bgcolor2" style="width: 393px">
		                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
					                    <tr>
						                    <td width="44%" align="center" height="24">&nbsp;
						                        <asp:Button 
						                            ID="btnLogin" 
						                            TabIndex="5"
						                            runat="server" 
						                            CssClass="go" 
						                            Text="Login"/>                         
						                        <asp:Button 
						                            id="btnReset" 
						                            TabIndex="6"
						                            runat="server" 
						                            CssClass="go" 
						                            Text="Reset" 
						                            CausesValidation="False"
						                            OnClick="btnReset_Click"/>&nbsp;
						                        <asp:ValidationSummary 
		                                            ID="ValidationSummary"
		                                            showmessagebox="true"
		                                            ShowSummary="false" 
		                                            runat="server" />
						                    </td>
					                    </tr>
				                    </table>
			                    </td>
		                    </tr>
		                    <tr>
		                        <td height="25" align="center" valign="middle" class="bgcolor8" style="width: 393px">
		                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
		                                <tr>
							                <td align="center" style="width: 100%; height: 19px;">
							                    <asp:Label ID="lblErrorMsg" runat="server"  CssClass="footer_error" Width="100%" ></asp:Label>
						                    </td>
						                </tr>
						            </table>
				                </td>
				            <tr>
	                    </table>
                    </td>
                </tr>
             </table>
        </td>
    </tr>
</table> 
</asp:Content>

