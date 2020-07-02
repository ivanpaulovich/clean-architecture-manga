import * as React from "react";
import { connect } from "react-redux";
import { ApplicationState } from "../store";
import * as UserStore from "../store/User";
import { Link } from "react-router-dom";
import { NavItem, NavLink } from "reactstrap";

type UserProps =
    UserStore.UserState &
    typeof UserStore.actionCreators;

class LoginStatus extends React.PureComponent<UserProps> {
    componentDidMount() {
        this.ensureDataFetched();
    }

    // This method is called when the route parameters change
    componentDidUpdate() {
        this.ensureDataFetched();
    }

    private ensureDataFetched() {
        this.props.requestLogin();
    }

    loginWithGitHub() {
        window.location.href = `/api/v1/Login/GitHub?ReturnUrl=${window.location.href}`;
    }

    loginWithGoogle() {
        window.location.href = `/api/v1/Login/Google?ReturnUrl=${window.location.href}`;
    }

    logout() {
        window.location.href = `/api/v1/Logout?ReturnUrl=${window.location.href}`;
    }

    render() {
        if (this.props.isLoggedIn) {
            return (
                <React.Fragment>
                    <NavItem>
                        <NavLink tag={Link} className="text-dark" to="/accounts">Manage Accounts</NavLink>
                    </NavItem>
                    <NavItem>
                        <a className="text-dark nav-link" onClick={this.logout.bind(this)} href="#">Logout</a>
                    </NavItem>
                </React.Fragment>
            );
        } else {
            return (
                <React.Fragment>
                    <NavItem>
                        <a className="text-dark nav-link" onClick={this.loginWithGitHub.bind(this)
} href="#">Login with GitHub</a>
                    </NavItem>
                    <NavItem>
                        <a className="text-dark nav-link" onClick={this.loginWithGoogle.bind(this)
} href="#">Login with Google</a>
                    </NavItem>
                </React.Fragment>
            );
        }
    }
}

export default connect(
    (state: ApplicationState) => state.user,
    UserStore.actionCreators
)(LoginStatus as any);
