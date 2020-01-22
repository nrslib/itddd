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
var react_router_dom_1 = require("react-router-dom");
var UserIndex = /** @class */ (function (_super) {
    __extends(UserIndex, _super);
    function UserIndex(props) {
        var _this = _super.call(this, props) || this;
        _this.state = {
            users: []
        };
        _this.load();
        return _this;
    }
    UserIndex.prototype.render = function () {
        return (React.createElement("div", null,
            React.createElement("h1", null, "User Index"),
            this.userList(),
            React.createElement(react_router_dom_1.Link, { className: "btn btn-primary", to: '/user/add' }, "Add User")));
    };
    UserIndex.prototype.userList = function () {
        var _this = this;
        return (React.createElement("table", { className: "table" },
            React.createElement("thead", null,
                React.createElement("tr", null,
                    React.createElement("th", null, "Id"),
                    React.createElement("th", null, "Detail"),
                    React.createElement("th", null, "Delete"))),
            React.createElement("tbody", null, this.state.users.map(function (x) {
                return React.createElement("tr", { key: x.id },
                    React.createElement("td", null, x.id),
                    React.createElement("td", null,
                        React.createElement(react_router_dom_1.Link, { className: "btn btn-default", to: "/user/detail/" + x.id }, "Detail")),
                    React.createElement("td", null,
                        React.createElement("button", { className: "btn btn-default", onClick: _this.handleDeleteButtonClick.bind(_this, x.id) }, "Delete")));
            }))));
    };
    UserIndex.prototype.load = function () {
        var _this = this;
        return fetch('api/User')
            .then(function (res) { return res.json(); })
            .then(function (data) { return _this.setState({ users: data.users }); });
    };
    UserIndex.prototype.handleDeleteButtonClick = function (id) {
        var _this = this;
        fetch("api/User/" + id, { method: 'DELETE' })
            .then(function (_) { return _this.load(); });
    };
    return UserIndex;
}(React.Component));
exports.UserIndex = UserIndex;
//# sourceMappingURL=UserIndex.js.map