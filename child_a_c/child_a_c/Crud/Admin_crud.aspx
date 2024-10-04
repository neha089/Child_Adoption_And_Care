<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_crud.aspx.cs" Inherits="admin_crud" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="my-4">Admin Dashboard</h1>
             <div class="d-flex justify-content-between align-items-center my-4">
     <h1>Admin Dashboard</h1>
     <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger" OnClick="Logout_Click" />
 </div>
            <h2>Orphanages</h2>
            <div class="row">
                <asp:Repeater ID="OrphanageRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4">
                            <div class="card mb-4 shadow-sm">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("name") %></h5>
                                    <p class="card-text">
                                        <strong>Address:</strong> <%# Eval("address") %><br />
                                        <strong>Phone:</strong> <%# Eval("phone_number") %><br />
                                        <strong>Email:</strong> <%# Eval("email") %><br />
                                        <strong>Contact Person:</strong> <%# Eval("contact_person") %><br />
                                        <strong>Capacity:</strong> <%# Eval("capacity") %><br />
                                        <strong>Number of Children:</strong> <%# Eval("number_of_children") %><br />
                                    </p>

                                    <strong>Orphanage Documents:</strong>
                                    <ul>
                                        <%# Eval("OrphanageDocuments") != DBNull.Value ? Eval("OrphanageDocuments") : "No documents available." %>
                                    </ul>

                                    <strong>Adoption Records:</strong>
                                    <ul>
                                        <%# Eval("AdoptionRecords") != DBNull.Value ? Eval("AdoptionRecords") : "No adoption records available." %>
                                    </ul>

                                    <strong>Home Studies:</strong>
                                    <ul>
                                        <%# Eval("HomeStudies") != DBNull.Value ? Eval("HomeStudies") : "No home studies available." %>
                                    </ul>

                                    <a href="javascript:void(0);" class="btn btn-danger" onclick="deleteOrphanage(<%# Eval("orphanage_id") %>);">Delete</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <script type="text/javascript">
            function deleteOrphanage(orphanageId) {
                if (confirm('Are you sure you want to delete this orphanage?')) {
                    window.location.href = 'admin_crud.aspx?deleteId=' + orphanageId;
                }
            }
        </script>
    </form>
</body>
</html>
