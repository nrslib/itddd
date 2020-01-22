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
var Layout_1 = require("./components/Layout");
var Home_1 = require("./components/Home");
var CircleIndex_1 = require("./components/pages/circle/index/CircleIndex");
var CircleDetail_1 = require("./components/pages/circle/detail/CircleDetail");
var CircleAdd_1 = require("./components/pages/circle/add/CircleAdd");
var CircleUpdate_1 = require("./components/pages/circle/update/CircleUpdate");
var CircleMemberAdd_1 = require("./components/pages/circle/member/add/CircleMemberAdd");
var UserIndex_1 = require("./components/pages/user/index/UserIndex");
var UserAdd_1 = require("./components/pages/user/add/UserAdd");
var UserDetail_1 = require("./components/pages/user/detail/UserDetail");
var UserUpdate_1 = require("./components/pages/user/update/UserUpdate");
require("./custom.css");
var App = /** @class */ (function (_super) {
    __extends(App, _super);
    function App() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    App.prototype.render = function () {
        return (React.createElement(Layout_1.Layout, null,
            React.createElement(react_router_dom_1.Route, { exact: true, path: '/', component: Home_1.Home }),
            React.createElement(react_router_dom_1.Route, { exact: true, path: '/circle', component: CircleIndex_1.CircleIndex }),
            React.createElement(react_router_dom_1.Route, { exact: true, path: '/circle/add', component: CircleAdd_1.CircleAdd }),
            React.createElement(react_router_dom_1.Route, { exact: true, path: '/circle/detail/:id', component: CircleDetail_1.CircleDetail }),
            React.createElement(react_router_dom_1.Route, { exact: true, path: '/circle/update/:id', component: CircleUpdate_1.CircleUpdate }),
            React.createElement(react_router_dom_1.Route, { exact: true, path: '/circle/member/add/:id', component: CircleMemberAdd_1.CircleMemberAdd }),
            React.createElement(react_router_dom_1.Route, { exact: true, path: '/user', component: UserIndex_1.UserIndex }),
            React.createElement(react_router_dom_1.Route, { exact: true, path: '/user/add', component: UserAdd_1.UserAdd }),
            React.createElement(react_router_dom_1.Route, { exact: true, path: '/user/detail/:id', component: UserDetail_1.UserDetail }),
            React.createElement(react_router_dom_1.Route, { exact: true, path: '/user/update/:id', component: UserUpdate_1.UserUpdate })));
    };
    return App;
}(React.Component));
exports.default = App;
//# sourceMappingURL=App.js.map