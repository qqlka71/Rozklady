<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Rozklady.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="../css/web.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/gridviewscroll.js"></script>
    <script type="text/javascript">
        var gridViewScroll = null;
        window.onload = function () {
            var options = new GridViewScrollOptions();
            options.elementID = "GridView1";
            options.width = "97%";
            options.height = 800;
//            options.freezeColumn = true;
//            options.freezeFooter = true;
//            options.freezeColumnCssClass = "GridViewScrollItemFreeze";
//            options.freezeFooterCssClass = "gvPager";
            freezeHeaderRowCount: 2,
//            options.freezeColumnCount = 3;
//            onscroll: function (scrollTop, scrollLeft) {
//                    console.log(scrollTop + " - " + scrollLeft);
            gridViewScroll = new GridViewScroll(options);
            gridViewScroll.enhance();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="UID" DataSourceID="odsRozklad" ForeColor="Black" PageSize="50" Font-Names="Courier New" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" AllowSorting="True">
                <Columns>
                    <asp:BoundField DataField="UID" HeaderText="UID" InsertVisible="False" ReadOnly="True" SortExpression="UID" Visible="False" />
                    <asp:TemplateField HeaderText="NrPolaczenia" SortExpression="NrPolaczenia">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NrPolaczenia") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NrPolaczenia") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Typ" SortExpression="Typ">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Typ") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Typ") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="StacjaPocz" SortExpression="StacjaPocz">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("StacjaPocz") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("StacjaPocz") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="StacjaKon" SortExpression="StacjaKon">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("StacjaKon") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("StacjaKon") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="StacjaPrzez1" SortExpression="StacjaPrzez1">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("StacjaPrzez1") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("StacjaPrzez1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="StacjaPrzez2" SortExpression="StacjaPrzez2">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("StacjaPrzez2") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("StacjaPrzez2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Przewoznik" SortExpression="Przewoznik">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Przewoznik") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Przewoznik") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NazwaPrzewoznika" SortExpression="NazwaPrzewoznika">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("NazwaPrzewoznika") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("NazwaPrzewoznika") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="id_rozkladu" SortExpression="id_rozkladu">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("id_rozkladu") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("id_rozkladu") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="identk" HeaderText="identk" SortExpression="identk" Visible="False" />
                    <asp:BoundField DataField="wazny_od" HeaderText="wazny_od" SortExpression="wazny_od" Visible="False" />
                    <asp:BoundField DataField="wazny_do" HeaderText="wazny_do" SortExpression="wazny_do" Visible="False" />
                    <asp:BoundField DataField="kalendarz" HeaderText="kalendarz" SortExpression="kalendarz" Visible="False" />
                    <asp:BoundField DataField="id_kursu" HeaderText="id_kursu" SortExpression="id_kursu" />
                    <asp:BoundField DataField="nr_przystanku" HeaderText="nr_przystanku" SortExpression="nr_przystanku" />
                    <asp:BoundField DataField="kod_przystanku" HeaderText="kod_przystanku" SortExpression="kod_przystanku" Visible="False" />
                    <asp:TemplateField HeaderText="godz_p" SortExpression="godz_p">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("godz_p") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("godz_p") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="godz_o" SortExpression="godz_o">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("godz_o") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("godz_o") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="stanowisko" SortExpression="stanowisko">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("stanowisko") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label12" runat="server" Text='<%# Bind("stanowisko") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="godz_przyjazdu" HeaderText="godz_przyjazdu" SortExpression="godz_przyjazdu" Visible="False" />
                    <asp:BoundField DataField="godz_odj" HeaderText="godz_odj" SortExpression="godz_odj" Visible="False" />
                    <asp:BoundField DataField="limit_sp" HeaderText="limit_sp" SortExpression="limit_sp" Visible="False" />
                    <asp:BoundField DataField="ile_dni_trwa_kurs" HeaderText="ile_dni_trwa_kurs" SortExpression="ile_dni_trwa_kurs" Visible="False" />
                    <asp:BoundField DataField="przystanek_poczatkowy" HeaderText="przystanek_poczatkowy" SortExpression="przystanek_poczatkowy" Visible="False" />
                    <asp:BoundField DataField="przystanek_koncowy" HeaderText="przystanek_koncowy" SortExpression="przystanek_koncowy" Visible="False" />
                    <asp:BoundField DataField="przystanek_tworzacy_1" HeaderText="przystanek_tworzacy_1" SortExpression="przystanek_tworzacy_1" Visible="False" />
                    <asp:BoundField DataField="przystanek_tworzacy_2" HeaderText="przystanek_tworzacy_2" SortExpression="przystanek_tworzacy_2" Visible="False" />
                    <asp:BoundField DataField="nr_bis" HeaderText="nr_bis" SortExpression="nr_bis" Visible="False" />
                    <asp:BoundField DataField="data" HeaderText="data" SortExpression="data" Visible="False" />
                    <asp:BoundField DataField="id_bisa" HeaderText="id_bisa" SortExpression="id_bisa" Visible="False" />
                    <asp:CheckBoxField DataField="auto_duzy_bus" HeaderText="auto_duzy_bus" SortExpression="auto_duzy_bus" Visible="False" />
                    <asp:CheckBoxField DataField="duzy_autobus" HeaderText="duzy_autobus" SortExpression="duzy_autobus" Visible="False" />
                    <asp:CheckBoxField DataField="diagram_kurs_odwolany" HeaderText="diagram_kurs_odwolany" SortExpression="diagram_kurs_odwolany" Visible="False" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            <br />
            <asp:Button ID="btnPobierzRozklad" runat="server" OnClick="btnPobierzRozklad_Click" Text="Pobierz rozkład" Width="150px" />
            &nbsp;
            <asp:Button ID="btnOpublikujRozklad" runat="server" OnClick="btnOpublikujRozklad_Click" Text="Opublikuj rozkład" Width="150px" />
            <br />
            <br />
            <asp:Label ID="lblKom" runat="server"></asp:Label>
            <asp:SqlDataSource ID="sqlRozklad" runat="server" ConnectionString="<%$ ConnectionStrings:RozkladyConnectionString %>" DataSourceMode="DataReader" SelectCommand="SELECT * FROM [Rozklad]"></asp:SqlDataSource>
        </div>
        <asp:ObjectDataSource ID="odsRozklad" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" OnInserting="odsRozklad_Inserting" SelectMethod="GetData" TypeName="Rozklady.RozkladyTableAdapters.RozkladTableAdapter" UpdateMethod="Update" OnUpdating="odsRozklad_Updating" OnDeleting="odsRozklad_Deleting">
            <DeleteParameters>
                <asp:Parameter Name="Original_UID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="NrPolaczenia" Type="Int32" />
                <asp:Parameter Name="Typ" Type="Int32" />
                <asp:Parameter Name="StacjaPocz" Type="String" />
                <asp:Parameter Name="StacjaPrzez1" Type="String" />
                <asp:Parameter Name="StacjaPrzez2" Type="String" />
                <asp:Parameter Name="StacjaKon" Type="String" />
                <asp:Parameter Name="Przewoznik" Type="Int32" />
                <asp:Parameter Name="NazwaPrzewoznika" Type="String" />
                <asp:Parameter Name="SymbolPrzewoznika" Type="String" />
                <asp:Parameter Name="id_rozkladu" Type="Int32" />
                <asp:Parameter Name="identk" Type="String" />
                <asp:Parameter Name="wazny_od" Type="DateTime" />
                <asp:Parameter Name="wazny_do" Type="DateTime" />
                <asp:Parameter Name="kalendarz" Type="Int32" />
                <asp:Parameter Name="id_kursu" Type="Int32" />
                <asp:Parameter Name="nr_przystanku" Type="Int32" />
                <asp:Parameter Name="kod_przystanku" Type="Int32" />
                <asp:Parameter DbType="Time" Name="godz_p" />
                <asp:Parameter DbType="Time" Name="godz_o" />
                <asp:Parameter Name="stanowisko" Type="String" />
                <asp:Parameter Name="limit_sp" Type="Int32" />
                <asp:Parameter Name="ile_dni_trwa_kurs" Type="Int32" />
                <asp:Parameter Name="przystanek_poczatkowy" Type="Int32" />
                <asp:Parameter Name="przystanek_koncowy" Type="Int32" />
                <asp:Parameter Name="przystanek_tworzacy_1" Type="Int32" />
                <asp:Parameter Name="przystanek_tworzacy_2" Type="Int32" />
                <asp:Parameter Name="nr_bis" Type="Int32" />
                <asp:Parameter Name="data" Type="DateTime" />
                <asp:Parameter Name="id_bisa" Type="Int32" />
                <asp:Parameter Name="auto_duzy_bus" Type="Boolean" />
                <asp:Parameter DbType="Time" Name="godz_odj" />
                <asp:Parameter DbType="Time" Name="godz_przyjazdu" />
                <asp:Parameter Name="duzy_autobus" Type="Boolean" />
                <asp:Parameter Name="diagram_kurs_odwolany" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="NrPolaczenia" Type="Int32" />
                <asp:Parameter Name="Typ" Type="Int32" />
                <asp:Parameter Name="StacjaPocz" Type="String" />
                <asp:Parameter Name="StacjaPrzez1" Type="String" />
                <asp:Parameter Name="StacjaPrzez2" Type="String" />
                <asp:Parameter Name="StacjaKon" Type="String" />
                <asp:Parameter Name="Przewoznik" Type="Int32" />
                <asp:Parameter Name="NazwaPrzewoznika" Type="String" />
                <asp:Parameter Name="SymbolPrzewoznika" Type="String" />
                <asp:Parameter Name="id_rozkladu" Type="Int32" />
                <asp:Parameter Name="identk" Type="String" />
                <asp:Parameter Name="wazny_od" Type="DateTime" />
                <asp:Parameter Name="wazny_do" Type="DateTime" />
                <asp:Parameter Name="kalendarz" Type="Int32" />
                <asp:Parameter Name="id_kursu" Type="Int32" />
                <asp:Parameter Name="nr_przystanku" Type="Int32" />
                <asp:Parameter Name="kod_przystanku" Type="Int32" />
                <asp:Parameter DbType="Time" Name="godz_p" />
                <asp:Parameter DbType="Time" Name="godz_o" />
                <asp:Parameter Name="stanowisko" Type="String" />
                <asp:Parameter Name="limit_sp" Type="Int32" />
                <asp:Parameter Name="ile_dni_trwa_kurs" Type="Int32" />
                <asp:Parameter Name="przystanek_poczatkowy" Type="Int32" />
                <asp:Parameter Name="przystanek_koncowy" Type="Int32" />
                <asp:Parameter Name="przystanek_tworzacy_1" Type="Int32" />
                <asp:Parameter Name="przystanek_tworzacy_2" Type="Int32" />
                <asp:Parameter Name="nr_bis" Type="Int32" />
                <asp:Parameter Name="data" Type="DateTime" />
                <asp:Parameter Name="id_bisa" Type="Int32" />
                <asp:Parameter Name="auto_duzy_bus" Type="Boolean" />
                <asp:Parameter DbType="Time" Name="godz_odj" />
                <asp:Parameter DbType="Time" Name="godz_przyjazdu" />
                <asp:Parameter Name="duzy_autobus" Type="Boolean" />
                <asp:Parameter Name="diagram_kurs_odwolany" Type="Boolean" />
                <asp:Parameter Name="Original_UID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:SqlDataSource ID="sqlCzyscRozklad" runat="server" ConnectionString="<%$ ConnectionStrings:RozkladyConnectionString %>" DeleteCommand="CzyscRozklad" DeleteCommandType="StoredProcedure" SelectCommand="CzyscRozklad" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <asp:SqlDataSource ID="sqlCzyscTrainSchedule" runat="server" ConnectionString="<%$ ConnectionStrings:RozkladyConnectionString %>" DeleteCommand="CzyscRozklad" DeleteCommandType="StoredProcedure" SelectCommand="CzyscRozklad" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <asp:ObjectDataSource ID="odsTrackerTrainSchedule" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Rozklady.TrackerTableAdapters.TrainScheduleTableAdapter" OnInserting="odsTrackerTrainSchedule_Inserting">
            <InsertParameters>
                <asp:Parameter Name="StacjaPocz" Type="String" />
                <asp:Parameter Name="StacjaPrzez1" Type="String" />
                <asp:Parameter Name="StacjaPrzez2" Type="String" />
                <asp:Parameter Name="StacjaKon" Type="String" />
                <asp:Parameter Name="Przewoznik" Type="String" />
                <asp:Parameter Name="NazwaPrzewoznika" Type="String" />
                <asp:Parameter Name="SymbolPrzewoznika" Type="String" />
                <asp:Parameter Name="FromStation" Type="Int32" />
                <asp:Parameter Name="FromThroughStation1" Type="Int32" />
                <asp:Parameter Name="FromThroughStation2" Type="Int32" />
                <asp:Parameter Name="FromThroughStation3" Type="Int32" />
                <asp:Parameter Name="FromThroughStation4" Type="Int32" />
                <asp:Parameter Name="ToStation" Type="Int32" />
                <asp:Parameter Name="ToThroughStation1" Type="Int32" />
                <asp:Parameter Name="ToThroughStation2" Type="Int32" />
                <asp:Parameter Name="ToThroughStation3" Type="Int32" />
                <asp:Parameter Name="ToThroughStation4" Type="Int32" />
                <asp:Parameter Name="FromThroughStation5" Type="Int32" />
                <asp:Parameter Name="FromThroughStation6" Type="Int32" />
                <asp:Parameter Name="FromThroughStation7" Type="Int32" />
                <asp:Parameter Name="FromThroughStation8" Type="Int32" />
                <asp:Parameter Name="ToThroughStation5" Type="Int32" />
                <asp:Parameter Name="ToThroughStation6" Type="Int32" />
                <asp:Parameter Name="ToThroughStation7" Type="Int32" />
                <asp:Parameter Name="ToThroughStation8" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Number" Type="String" />
                <asp:Parameter Name="CarrierId" Type="Int32" />
                <asp:Parameter Name="TrackId" Type="Int32" />
                <asp:Parameter Name="Sectors" Type="String" />
                <asp:Parameter Name="Departure" Type="Boolean" />
                <asp:Parameter Name="DepartureTime" DbType="Time" />
                <asp:Parameter Name="Arrival" Type="Boolean" />
                <asp:Parameter Name="ArrivalTime" DbType="Time" />
                <asp:Parameter Name="TransDate" Type="DateTime" />
                <asp:Parameter Name="Active" Type="Boolean" />
                <asp:Parameter Name="ParentId" Type="Int64" />
                <asp:Parameter Name="ArrivalDelay" Type="Int32" />
                <asp:Parameter Name="DepartureDelay" Type="Int32" />
                <asp:Parameter Name="ArrivalText" Type="String" />
                <asp:Parameter Name="DepartureText" Type="String" />
                <asp:Parameter Name="RealDepartureTime" Type="DateTime" />
                <asp:Parameter Name="RealArrivalTime" Type="DateTime" />
                <asp:Parameter Name="ActiveZap" Type="Int32" />
                <asp:Parameter Name="Typ" Type="Int32" />
                <asp:Parameter Name="OriginalTrackId" Type="Int32" />
                <asp:Parameter Name="TrackingId" Type="Int32" />
                <asp:Parameter Name="ParkingSectors" Type="String" />
                <asp:Parameter Name="ozn" Type="String" />
                <asp:Parameter Name="Deleted" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
