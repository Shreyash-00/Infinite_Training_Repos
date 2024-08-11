<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Validator.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form Validator</title>

<!-- Include Basic Bootstrap CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .error {
            color: red;
        }
        .validation-summary {
            color: red;
        }
    </style>
</head>
<body>
    <form id="mainForm" runat="server" class="container mt-4">
        <div>
            <h2 class="mb-4">Enter your details:</h2>

            <div class="form-group">
                <asp:Label ID="labelFirstName" runat="server" CssClass="form-label" Text="First Name: "></asp:Label>
                <asp:TextBox ID="inputFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateFirstName" runat="server" ControlToValidate="inputFirstName"
                    ErrorMessage="* Required" CssClass="error"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="labelLastName" runat="server" CssClass="form-label" Text="Last Name: "></asp:Label>
                <asp:TextBox ID="inputLastName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateLastName" runat="server" ControlToValidate="inputLastName"
                    ErrorMessage="* Required" CssClass="error"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="compareLastName" runat="server" ControlToValidate="inputLastName"
                    ControlToCompare="inputFirstName" Operator="NotEqual" ErrorMessage="Must differ from first name" CssClass="error"></asp:CompareValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="labelStreetAddress" runat="server" CssClass="form-label" Text="Street Address: "></asp:Label>
                <asp:TextBox ID="inputStreetAddress" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateStreetAddress" runat="server" ControlToValidate="inputStreetAddress"
                    ErrorMessage="* Required" CssClass="error"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexStreetAddress" runat="server" ControlToValidate="inputStreetAddress"
                    ValidationExpression=".{2,}" ErrorMessage="At least 2 characters" CssClass="error"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="labelTown" runat="server" CssClass="form-label" Text="Town/City: "></asp:Label>
                <asp:TextBox ID="inputTown" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateTown" runat="server" ControlToValidate="inputTown"
                    ErrorMessage="* Required" CssClass="error"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexTown" runat="server" ControlToValidate="inputTown"
                    ValidationExpression=".{2,}" ErrorMessage="At least 2 characters" CssClass="error"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="labelPostalCode" runat="server" CssClass="form-label" Text="Postal Code: "></asp:Label>
                <asp:TextBox ID="inputPostalCode" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validatePostalCode" runat="server" ControlToValidate="inputPostalCode"
                    ErrorMessage="* Required" CssClass="error"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexPostalCode" runat="server" ControlToValidate="inputPostalCode"
                    ValidationExpression="\d{6}" ErrorMessage="Format: 123456" CssClass="error"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="labelPhoneNumber" runat="server" CssClass="form-label" Text="Phone Number: "></asp:Label>
                <asp:TextBox ID="inputPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validatePhoneNumber" runat="server" ControlToValidate="inputPhoneNumber"
                    ErrorMessage="* Required" CssClass="error"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexPhoneNumber" runat="server" ControlToValidate="inputPhoneNumber"
                    ValidationExpression="\d{10}|\d{2}-\d{10}" ErrorMessage="Format: 1234567890 or 91-1234567890" CssClass="error"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="labelEmailAddress" runat="server" CssClass="form-label" Text="Email: "></asp:Label>
                <asp:TextBox ID="inputEmailAddress" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateEmailAddress" runat="server" ControlToValidate="inputEmailAddress"
                    ErrorMessage="* Required" CssClass="error"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexEmailAddress" runat="server" ControlToValidate="inputEmailAddress"
                    ValidationExpression="\w+@\w+\.\w+" ErrorMessage="Format: xyzz@abc.com" CssClass="error"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            </div>

            <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Validation Errors"
                CssClass="validation-summary alert alert-danger" />
        </div>
    </form>
</body>
</html>
