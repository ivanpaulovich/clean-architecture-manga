import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as UserStore from '../store/User';
import {Link} from "react-router-dom";
import {NavItem, NavLink} from "reactstrap";

type UserProps =
    UserStore.UserState &
    typeof UserStore.actionCreators;

class LoginStatus extends React.PureComponent<UserProps> {
    public componentDidMount() {
        this.ensureDataFetched();
    }

    // This method is called when the route parameters change
    public componentDidUpdate() {
        this.ensureDataFetched();
    }

    private ensureDataFetched() {
        this.props.requestLogin();
    }

    public render() {
        if (this.props.isLoggedIn) {
            return (
                <React.Fragment>
                    <NavItem>
                        <a href="/api/v1/Logout?RedirectUrl=/">Logout</a>
                    </NavItem>
                </React.Fragment>
            )
        }
        else
        {
            return (
                <React.Fragment>
                    <NavItem>
                        <a href="/api/v1/Login/GitHub">Login with GitHub</a>
                    </NavItem>
                    <NavItem>
                        <a href="/api/v1/Login/Google">Login with Google</a>
                    </NavItem>
                </React.Fragment>
            )
        }
    }
};

export default connect(
    (state: ApplicationState) => state.user,
    UserStore.actionCreators
)(LoginStatus as any);
