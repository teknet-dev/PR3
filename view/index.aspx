<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PR3.view.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../library/css/style.css" rel="stylesheet" />
    <script src="/library/js/jquery-1.8.2.js"></script>
    <link href="../library/css/style.css" rel="stylesheet" />
    <link href="/library/css/jquery.Jcrop.css" rel="stylesheet" />
      <script src="/library/js/jquery.Jcrop.js"></script>
    
        <script src="../library/js/bootstrap-filestyle.js"></script>
    <script src="../library/js/bootstrap-filestyle.min.js"></script>
    <script src="../library/js/bootstrap.js"></script>


     <link href="../library/css/bootstrap-theme.css" rel="stylesheet" />
     <link href="../library/css/bootstrap-theme.min.css" rel="stylesheet" />
     <link href="../library/css/bootstrap.css" rel="stylesheet" />
    <link href="../library/css/bootstrap.min.css" rel="stylesheet" />
    
    <link href="../library/css/jquery.Jcrop.min.css" rel="stylesheet" />
    
    <script src="../library/js/bootstrap.min.js"></script>
    <script src="../library/js/jquery-1.7.1.min.js"></script>
    
       <link href="../library/css/style.css" rel="stylesheet" />
    <script src="/library/js/jquery-1.8.2.js"></script>
    <link href="../library/css/style.css" rel="stylesheet" />
    <link href="../library/css/jquery.Jcrop.css" rel="stylesheet" />
    <script src="../library/js/jquery.Jcrop.js"></script>
    
</head>

<body>
   
    <center>
      <form id="form1" runat="server" style="margin-left:30%!important;">
       
          <asp:Panel ID="Panel2" class="pan2" runat="server" Height="142px" Width="224px">
             <asp:Image ID="Image1" runat="server" ImageUrl="~/img/cle.gif"  Width="105px"/>
          </asp:Panel>
 
  
          <asp:Panel ID="Panel1" runat="server" class="pan1" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="588px" Height="254px" style="margin-top: 0px">
           
             <table class="auto-style23" style="margin-top: 30px;">
                <tr>
                   <td class="auto-style25" style="line-height: 4;">
                      <div class="form-group">
                         <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
                      </div>
                   </td>

                   <td class="auto-style26">
                        <asp:TextBox class="form-control" ID="login" runat="server" Height="45px" Width="320px"></asp:TextBox>
                   </td>
                 </tr>
            
                   
                 <tr>
                    <td class="auto-style25">
                      <div class="form-group">
                         <asp:Label ID="Mdp" runat="server" Text="Mot de passe"></asp:Label>
                      </div>
                    </td>

                    <td class="auto-style26">
                       <asp:TextBox ID="passe" runat="server" class="form-control" Height="45px" type="password" Width="318px" style="margin: 15px;"></asp:TextBox>
                    </td>
                 </tr>
             
                 <tr>
                    <td class="auto-style25"></td>

                    <td class="auto-style26">
                        <asp:Button ID="Button2" runat="server" class=" btn btn-primary" OnClick="Button2_Click" Text="Se connecter" Width="150px" />
                        <asp:Button ID="Button1" runat="server" class=" btn btn-primary" OnClick="Button1_Click" Text="Annuler" Width="150px" />
                    </td>
                </tr>
              
                   
           </table>
 
      
        </asp:Panel>
   
      </form>
   </center>
</body>
</html>
