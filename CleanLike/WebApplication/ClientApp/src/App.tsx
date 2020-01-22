import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { CircleIndex } from "./components/pages/circle/index/CircleIndex";
import { CircleDetail } from "./components/pages/circle/detail/CircleDetail";
import { CircleAdd } from "./components/pages/circle/add/CircleAdd";
import { CircleUpdate } from "./components/pages/circle/update/CircleUpdate";
import { CircleMemberAdd } from "./components/pages/circle/member/add/CircleMemberAdd";
import { UserIndex } from "./components/pages/user/index/UserIndex";
import { UserAdd } from "./components/pages/user/add/UserAdd";
import { UserDetail } from "./components/pages/user/detail/UserDetail";
import { UserUpdate } from "./components/pages/user/update/UserUpdate";

import './custom.css';

export default class App extends React.Component<{}, {}> {
    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />

                <Route exact path='/circle' component={CircleIndex} />
                <Route exact path='/circle/add' component={CircleAdd} />
                <Route exact path='/circle/detail/:id' component={CircleDetail} />
                <Route exact path='/circle/update/:id' component={CircleUpdate} />
                <Route exact path='/circle/member/add/:id' component={CircleMemberAdd} />

                <Route exact path='/user' component={UserIndex} />
                <Route exact path='/user/add' component={UserAdd} />
                <Route exact path='/user/detail/:id' component={UserDetail} />
                <Route exact path='/user/update/:id' component={UserUpdate} />
            </Layout>
        );
    }
}