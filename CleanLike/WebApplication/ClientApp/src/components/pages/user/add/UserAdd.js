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
var UserAdd = /** @class */ (function (_super) {
    __extends(UserAdd, _super);
    function UserAdd(props) {
        var _this = _super.call(this, props) || this;
        _this.handleSubmit = function (e) {
            e.preventDefault();
            if (!_this.state.name) {
                return;
            }
            var payload = {
                userName: _this.state.name
            };
            fetch('api/User', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload),
            })
                .then(function (res) { return res.json(); })
                .then(function (data) {
                _this.props.history.push('/user');
            });
        };
        _this.handleNameChange = function (e) {
            _this.setState({ name: e.currentTarget.value });
        };
        _this.state = {
            name: ''
        };
        return _this;
    }
    UserAdd.prototype.render = function () {
        return (React.createElement("div", null,
            React.createElement("h1", null, "User Add"),
            React.createElement("form", { onSubmit: this.handleSubmit },
                React.createElement("div", { className: "form-group" },
                    React.createElement("input", { type: "text", value: this.state.name, onChange: this.handleNameChange })),
                React.createElement("button", { type: "submit", value: "Submit", className: "btn btn-primary" }, "Submit")),
            React.createElement(react_router_dom_1.Link, { className: "btn btn-default", to: "/user" }, "Go back")));
    };
    return UserAdd;
}(React.Component));
exports.UserAdd = UserAdd;
//# sourceMappingURL=UserAdd.js.map