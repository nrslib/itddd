"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var Home = /** @class */ (function (_super) {
    __extends(Home, _super);
    function Home() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Home.prototype.render = function () {
        return (React.createElement("div", null,
            React.createElement("h1", null, "Introduction to DDD"),
            React.createElement("p", null, "Welcome to your new ddd application, built with:"),
            React.createElement("ul", null,
                React.createElement("li", null,
                    React.createElement("a", { href: 'https://get.asp.net/' }, "ASP.NET Core"),
                    " and ",
                    React.createElement("a", { href: 'https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx' }, "C#"),
                    " for cross-platform server-side code"),
                React.createElement("li", null,
                    React.createElement("a", { href: 'https://facebook.github.io/react/' }, "React"),
                    " for client-side code"),
                React.createElement("li", null,
                    React.createElement("a", { href: 'http://getbootstrap.com/' }, "Bootstrap"),
                    " for layout and styling")),
            React.createElement("p", null, "To help you get started, we have also set up:"),
            React.createElement("ul", null,
                React.createElement("li", null,
                    React.createElement("strong", null, "Client-side navigation"),
                    ". For example, click ",
                    React.createElement("em", null, "Counter"),
                    " then ",
                    React.createElement("em", null, "Back"),
                    " to return here."),
                React.createElement("li", null,
                    React.createElement("strong", null, "Development server integration"),
                    ". In development mode, the development server from ",
                    React.createElement("code", null, "create-react-app"),
                    " runs in the background automatically, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file."),
                React.createElement("li", null,
                    React.createElement("strong", null, "Efficient production builds"),
                    ". In production mode, development-time features are disabled, and your ",
                    React.createElement("code", null, "dotnet publish"),
                    " configuration produces minified, efficiently bundled JavaScript files.")),
            React.createElement("p", null,
                "The ",
                React.createElement("code", null, "ClientApp"),
                " subdirectory is a standard React application based on the ",
                React.createElement("code", null, "create-react-app"),
                " template. If you open a command prompt in that directory, you can run ",
                React.createElement("code", null, "npm"),
                " commands such as ",
                React.createElement("code", null, "npm test"),
                " or ",
                React.createElement("code", null, "npm install"),
                ".")));
    };
    return Home;
}(React.Component));
exports.Home = Home;
//# sourceMappingURL=Home.js.map