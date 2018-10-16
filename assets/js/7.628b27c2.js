(window.webpackJsonp=window.webpackJsonp||[]).push([[7],{168:function(e,t,r){"use strict";r.r(t);var s=r(0),a=Object(s.a)({},function(){var e=this,t=e.$createElement,r=e._self._c||t;return r("div",{staticClass:"content"},[e._m(0),e._v(" "),e._m(1),e._v(" "),e._m(2),e._v(" "),r("div",{staticClass:"tip custom-block"},[r("p",{staticClass:"custom-block-title"},[e._v("NOTE:")]),e._v(" "),r("p",[e._v("Place this work in your classroom private Exercise repository; a link to the repository can be found on the "),r("a",{attrs:{href:"https://moodle.nait.ca",target:"_blank",rel:"noopener noreferrer"}},[e._v("Moodle Site"),r("OutboundLink")],1),e._v(" for this course.")])]),e._v(" "),e._m(3),e._v(" "),e._m(4),e._v(" "),e._m(5),e._v(" "),e._m(6),e._v(" "),r("p",[e._v("Add the following not mapping properties:")]),e._v(" "),e._m(7),e._v(" "),r("p",[e._v("! [GroceryList ERD] (./ef/grocerylist_erd.png)")]),e._v(" "),e._m(8),e._v(" "),e._m(9),e._v(" "),e._m(10),e._v(" "),e._m(11),e._v(" "),e._m(12),e._v(" "),e._m(13),e._v(" "),r("p",[e._v("! [Sample query result] (./ef/ExerciseQuery.png)")]),e._v(" "),e._m(14),e._v(" "),e._m(15),e._v(" "),r("p",[e._v("! [ListView CRUD] (./ef/ExerciseCRUD.png)")])])},[function(){var e=this.$createElement,t=this._self._c||e;return t("h1",{attrs:{id:"entity-framework-code-first-crud-exercise-4-marks"}},[t("a",{staticClass:"header-anchor",attrs:{href:"#entity-framework-code-first-crud-exercise-4-marks","aria-hidden":"true"}},[this._v("#")]),this._v(" Entity Framework - Code First CRUD Exercise (4 Marks)")])},function(){var e=this.$createElement,t=this._self._c||e;return t("p",[this._v("Be aware that this is the first in a series of cumulative exercises. You must be prepared to complete each exercise in light of the possibility that any given exercise may depend on the "),t("strong",[this._v("correct")]),this._v(" implementation of previous exercises.")])},function(){var e=this.$createElement,t=this._self._c||e;return t("h2",{attrs:{id:"private-github-repo-only"}},[t("a",{staticClass:"header-anchor",attrs:{href:"#private-github-repo-only","aria-hidden":"true"}},[this._v("#")]),this._v(" Private GitHub Repo Only")])},function(){var e=this.$createElement,t=this._self._c||e;return t("h4",{attrs:{id:"setup"}},[t("a",{staticClass:"header-anchor",attrs:{href:"#setup","aria-hidden":"true"}},[this._v("#")]),this._v(" Setup")])},function(){var e=this.$createElement,t=this._self._c||e;return t("p",[this._v("Use the following names for the parts of your"),t("br"),this._v("\nCreate a new VS Solution called "),t("code",[this._v("GroceryListSolution")]),this._v(". Place two class projects into this solution called GroceryListSystem and GroceryList.Data, along with a web application called WebApp. GroceryList.Data will have 3 folder called Entities, DTOs and POCOs. GroceryListSystem will have 2 folders DAL and BLL. Add the NuGet package, EntityFramework, to your class libraries. Add references to your solution where needed/appropriate.")])},function(){var e=this.$createElement,t=this._self._c||e;return t("h4",{attrs:{id:"entities"}},[t("a",{staticClass:"header-anchor",attrs:{href:"#entities","aria-hidden":"true"}},[this._v("#")]),this._v(" Entities")])},function(){var e=this,t=e.$createElement,r=e._self._c||t;return r("p",[e._v("Create the database context and entity classes by adding an "),r("strong",[e._v("ADO.NET Entity Data Model")]),e._v(" using "),r("em",[e._v("Code First from database")]),e._v(". Create the entity classes in the Entity folder. Name the context class GroceryListContext. Use GroceryListDB as the connection string name. "),r("code",[e._v("[Required]")]),e._v(", and "),r("code",[e._v("[StringLength]")]),e._v(" notations in your entities will not have error messages. You must place an ErrorMessage parameter within each notation such as that the message will be specific to the entity attribute.")])},function(){var e=this,t=e.$createElement,r=e._self._c||t;return r("ul",[r("li",[e._v("Customer: FullName: returns the customer full name as LastName, Firstname")]),e._v(" "),r("li",[e._v("Customer: CityCustomer: returns the city and customer full name as City: LastName, Firstname")]),e._v(" "),r("li",[e._v("Picker: FullName: returns the picker full name as LastName, Firstname")]),e._v(" "),r("li",[e._v("Product: DescriptionUnitSize: returns the description and unitsize as Description (UnitSize)")]),e._v(" "),r("li",[e._v("Store: CityLocation: returns the city and location as City:Location")])])},function(){var e=this.$createElement,t=this._self._c||e;return t("h4",{attrs:{id:"context-class"}},[t("a",{staticClass:"header-anchor",attrs:{href:"#context-class","aria-hidden":"true"}},[this._v("#")]),this._v(" Context Class")])},function(){var e=this.$createElement,t=this._self._c||e;return t("p",[this._v("Move the "),t("strong",[this._v("Context class")]),this._v(" to the DAL folder from the Entities folder; alter the namespace to GroceryListSystem.DAL; and include any necessary using statements. Remove the Context class from the entity folder. Create an appropriate web connection string file pointing to the database GroceryList. Add the "),t("code",[this._v("<context>")]),this._v(" tag in the web.config file under the "),t("code",[this._v("<entityframe>")]),this._v(" tag. The context class is to be restricted to internal project access only.")])},function(){var e=this.$createElement,t=this._self._c||e;return t("h4",{attrs:{id:"bll-controller-classes"}},[t("a",{staticClass:"header-anchor",attrs:{href:"#bll-controller-classes","aria-hidden":"true"}},[this._v("#")]),this._v(" BLL Controller Classes")])},function(){var e=this.$createElement,t=this._self._c||e;return t("p",[this._v("Create "),t("strong",[this._v("BLL controller classes")]),this._v(" for the two entities: Category and Product. The classes will allow ODS access to methods. Both classses will have an appropriate List() and Get(int keyvalue) methods (exposed). The ProductController will have a method which will recieve an integer parameter representing a category and return all products within that category. The ProductController will implement Add(Product), Update(Product), Delete(Product) and Delete(int productid) methods. The overloaded Delete(int productid) will do the actual delete of the product record of the database.")])},function(){var e=this.$createElement,t=this._self._c||e;return t("h4",{attrs:{id:"web-page-query"}},[t("a",{staticClass:"header-anchor",attrs:{href:"#web-page-query","aria-hidden":"true"}},[this._v("#")]),this._v(" Web Page: Query")])},function(){var e=this.$createElement,t=this._self._c||e;return t("p",[this._v("Create a web page that will display the product data related to a supplied category. Use "),t("strong",[this._v("only ODS wired controls")]),this._v(" to handle the data. Categories should be displayed in a ordered drop down list. Display the ordered product data in a customized data control which obtains its input parameter value from the drop down list. Your display requires appropriate page title, labels and layout/formatting. You will need a button on your page to force a post back. This page "),t("strong",[this._v("must")]),this._v(" be accessiable by the site master menu.")])},function(){var e=this.$createElement,t=this._self._c||e;return t("h4",{attrs:{id:"web-page-crud"}},[t("a",{staticClass:"header-anchor",attrs:{href:"#web-page-crud","aria-hidden":"true"}},[this._v("#")]),this._v(" Web Page: CRUD")])},function(){var e=this.$createElement,t=this._self._c||e;return t("p",[this._v("Create a web page that will maintain the Product entity. You will be requried to insert, update or delete records to this entity. The Category data will be handled via an appropriate dropdownlist. "),t("strong",[this._v("Use a ODS wired ListView control")]),this._v(" to maintain the data. Appropriate formatting is required on the display lines. This page "),t("strong",[this._v("must")]),this._v(" be accessiable by the site master menu.")])}],!1,null,null,null);a.options.__file="ef.md";t.default=a.exports}}]);