import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as UserStore from '../store/User';

type UserProps =
    UserStore.UserState &
    typeof UserStore.actionCreators;

class LoginStatus extends React.PureComponent<UserProps> {
    public render() {
        return (
            <a href="">Test</a>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.user,
    UserStore.actionCreators
)(LoginStatus);
