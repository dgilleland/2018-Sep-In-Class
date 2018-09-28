<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <img src="Images/NorthwindLogo.png" class="pull-right" />
        <h1>Northwind 2018</h1>
        <p class="lead"><i>Northwind 2018</i> is a modification of the traditional Northwind Trader's database.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Purchasing</h2>
            <p>The Staffing subsystem is managed by:</p>
            <ul>
                <li><b>Steven Buchanan</b> - Sales Manager</li>
                <li><b>Laura Callahan</b> - Inside Sales Coordinator</li>
            </ul>
            <img src="Images/Northwind%20Traders%20-%20Purchasing.png" class="img-responsive img-thumbnail" />
        </div>
        <div class="col-md-4">
            <h2>Sales</h2>
            <p>At Northwind Traders, our customers are small to medium sized companies who purchase our products either for resale or for use in their eating establishments. Northwind is still a little "old school". Customers don't order products directly online; rather, they phone or fax in orders to our sales team. Each order is managed by a <i>Sales Representative</i>.</p>
            <p>The Sales subsystem can be managed by all the employees of the system, but orders are primarily handled by Sales Representatives.</p>
            <img src="Images/Northwind%20Traders%20-%20Sales.png" class="img-responsive img-thumbnail" />
        </div>
        <div class="col-md-4">
            <h2>Staffing</h2>
            <p>The Staffing subsystem is managed by:</p>
            <ul>
                <li><b>Andrew Fuller</b> - Vice President, Sales</li>
                <li><b>Steven Buchanan</b> - Sales Manager</li>
            </ul>
            <img src="Images/Northwind%20Traders%20-%20Staffing.png" class="img-responsive img-thumbnail" />
        </div>
    </div>
    <hr />
    <div class="row bg-info">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
