Imports System
Imports System.Net
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Genius.BusinessLogics
Imports System.Globalization

Partial Class Login


 

    Inherits System.Web.UI.Page
    Dim info1 As CultureInfo = New CultureInfo("en-GB")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim timeout As String = HttpContext.Current.Request("timeout")
        If Not Page.IsPostBack Then
            If timeout = "out" Then
                Dim myMessage As String = "Session TimeOut"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "hi", "alert('Session Expired')", True)

            End If
            Dim gLogOut As String = HttpContext.Current.Request("LogOut")
            If gLogOut = "Yes" Then
                Dim ErrorMessage As New RespondsReturn
                Dim _LoginHistory As New LoginHistory(ErrorMessage)
                _LoginHistory.IPAddress = Session.SessionID
                _LoginHistory.LogOutTime = gDateAndTime.GetStrDateTimeSQL(CType(Session("ServerDateTime"), DateTime), CType(Session("ClientDateTime"), DateTime))
                _LoginHistory.AuthorizedOrNot = True
                Try
                    ErrorMessage = LoginHistory.Update(_LoginHistory, "Edit")
                Catch ex As Exception
                End Try
                Session.Clear()

            End If
            txtUserName.Focus()
        End If
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim dt As DateTime = System.DateTime.Now.Date
        Dim chkdt As String = "30/06/2013"
        Dim valid_dt = DateTime.Parse(chkdt, info1)

        'If dt <= valid_dt Then




        Dim gUser As New UserMaster(txtUserName.Text.Trim, txtPassword.Text.Trim, "SPEED", "ho")
        Dim gNewUser As UserMaster = UserMaster.SelectOneByUserName(txtUserName.Text.Trim)
        Dim gResponds As New RespondsReturn
        gResponds = UserMaster.CheckUserLoginPass(gUser)
        If gResponds.Responds Then
            Session.Add("UserId", gNewUser.gId)
            Session.Add("UserName", gNewUser.UserName)
            Session.Add("GroupId", gNewUser.GroupId)
            Session.Add("myUserGroupId", gNewUser.GroupId)
            Session.Add("CompanyCode", gUser.CompanyCode)
            Session.Add("CompanyId", CompanyMaster.GetCompanyId(gUser.CompanyCode))
            Session.Add("OrgCode", gUser.OrgCode)
            Session.Add("OrgId", OrganizationMaster.GetOrganizationId(gUser.OrgCode))
            Session.Add("ServerDateTime", DateTime.Now())
            Session.Add("ClientDateTime", DateTime.Now())
            Session.Add("Privilege", gNewUser.Privilege)
            Dim _CompanyMaster As CompanyMaster = CompanyMaster.SelectOne(CompanyMaster.GetCompanyId(gUser.CompanyCode))
            Dim pobox As String
            Dim Telephone As String
            Dim Email As String
            Dim CompanyName As String

            CompanyName = _CompanyMaster.CompanyName
            pobox = _CompanyMaster.POBox & " " & _CompanyMaster.Adress
            Telephone = "Tel.No: " & _CompanyMaster.Telephone1 & " Fax.No: " & _CompanyMaster.Fax
            Email = _CompanyMaster.Email

            Session.Add("CompanyName", CompanyName)
            Session.Add("CompanyPoBox", pobox)
            Session.Add("CompanyPhone", Telephone)
            Session.Add("Email", Email)

            Dim _LoginHistory As New LoginHistory(gResponds)
            Dim myIP As IPAddress = PoornaERP.Business.Network.FindIPAddress(True)
            Dim mySTR_IP As String = myIP.ToString()
            _LoginHistory.UserId = gNewUser.gId
            _LoginHistory.CompanyId = CompanyMaster.GetCompanyId("SPEED")
            _LoginHistory.OrgId = OrganizationMaster.GetOrganizationId("ho")
            _LoginHistory.LoginDateTime = gDateAndTime.GetDateTime(CType(Session("ServerDateTime"), DateTime), CType(Session("ClientDateTime"), DateTime))
            _LoginHistory.LoginTime = gDateAndTime.GetStrDateTimeSQL(CType(Session("ServerDateTime"), DateTime), CType(Session("ClientDateTime"), DateTime))
            _LoginHistory.LogOutDateTime = gDateAndTime.GetDateTime(CType(Session("ServerDateTime"), DateTime), CType(Session("ClientDateTime"), DateTime))
            _LoginHistory.LogOutTime = gDateAndTime.GetStrDateTimeSQL(CType(Session("ServerDateTime"), DateTime), CType(Session("ClientDateTime"), DateTime))
            _LoginHistory.IPAddress = mySTR_IP
            _LoginHistory.AuthorizedOrNot = False
            Try
                gResponds = LoginHistory.Update(_LoginHistory, "Add")
            Catch ex As Exception

            End Try
            If gNewUser.PassWordOnNextLogon Then
                Response.Redirect("~/ChangePassWord.aspx")
            Else
                Response.Redirect("MasterPages/myHome.aspx")
            End If
        Else
            Dim _UnAuthorizedHistory As New UnAuthorizedHistory(gResponds)
            Dim _ErrorMessage As New RespondsReturn
            _UnAuthorizedHistory.UserName = txtUserName.Text.Trim
            _UnAuthorizedHistory.CompanyName = "SPEED"
            _UnAuthorizedHistory.OrgName = "ho"
            _UnAuthorizedHistory.IPAddress = gResponds.Message
            _UnAuthorizedHistory.LoginDateTime = gDateAndTime.GetDateTime(CType(Session("ServerDateTime"), DateTime), CType(Session("ClientDateTime"), DateTime))
            _UnAuthorizedHistory.LoginTime = gDateAndTime.GetStrDateTimeSQL(CType(Session("ServerDateTime"), DateTime), CType(Session("ClientDateTime"), DateTime))
            Try
                _ErrorMessage = UnAuthorizedHistory.Update(_UnAuthorizedHistory, "Add")
            Catch ex As Exception
            End Try
            lblErrorMsg.Text = gResponds.Message
            Page.Focus()
        End If
        'Else
        '    lblErrorMsg.Text = "Please Contact Software Vendor"
        'End If
    End Sub

    ' Sub routin for add button event
    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        EmptyVariable()
        txtUserName.Focus()
    End Sub

    ' Sub routin to store null value to variabel
    Protected Sub EmptyVariable()
        txtUserName.Text = ""
        txtPassword.Text = ""
    End Sub
End Class
