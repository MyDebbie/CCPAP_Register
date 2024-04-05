<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RegisterForCcpap.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register for CCPAP</title>
    <link rel="stylesheet" href="Styles/StyleSheet1.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card-container">
            <main class="main-content">
                <h2> Register Person for CCPAP</h2>
                <div>
                    <asp:TextBox ID="txtNom" class="form-control textbox-space" placeholder="Entrer le Nom" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtPrenom" class="form-control textbox-space" placeholder="Entrer le Prénom" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="txtAdresse" class="form-control textbox-space" placeholder="Entrer l'Adresse" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtDdn" class="form-control textbox-space" placeholder="Entrer la date de Naissance" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="txtNumero" class="form-control textbox-space" placeholder="Entrer le Numéro de Téléphone" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtDate" class="form-control textbox-space" placeholder="la date" runat="server"></asp:TextBox>
                </div>
                <div>
                   <asp:Button ID="btnSave" runat="server" Text="Enregistrer" OnClick="btnSave_Click" /> 
                   <asp:Button ID="btnCancel" runat="server" Text="Annuler" OnClick="btnCancel_Click" /> 
                </div>
                <div>
                   <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
                </main>

        </div>
    </form>
</body>
</html>
