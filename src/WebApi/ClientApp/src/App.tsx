import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Accounts from './components/Accounts';
import Register from './components/Register';
import Deposit from './components/Deposit';
import Withdraw from "./components/Withdraw";

import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/accounts' component={Accounts} />
        <Route exact path='/register' component={Register} />
        <Route path='/deposit/:accountId' component={Deposit} />
        <Route path='/withdraw/:accountId' component={Withdraw} />
    </Layout>
);
