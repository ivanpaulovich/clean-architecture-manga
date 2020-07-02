import { Action, Reducer } from "redux";
import { AppThunkAction } from "./index";

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface UserState {
    isLoggedIn: boolean;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.
// Use @typeName and isActionType for type detection that works even after serialization/deserialization.

export interface RequestLoginAction {
    type: "REQUEST_LOGIN"
}

export interface ReceiveLoginAction {
    type: "RECEIVE_LOGIN";
    isLoggedIn: boolean;
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
export type KnownAction = RequestLoginAction | ReceiveLoginAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestLogin: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        fetch(`api/v1/Login/GetUserInfo`)
            .then((response) => {
                if (response.status === 200) {
                    dispatch({ type: "RECEIVE_LOGIN", isLoggedIn: true });
                } else if (response.status === 401) {
                    dispatch({ type: "RECEIVE_LOGIN", isLoggedIn: false });
                }
            })
            .catch((err) => {
                dispatch({ type: "RECEIVE_LOGIN", isLoggedIn: false });
            });
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

export const reducer: Reducer<UserState> = (state: UserState | undefined, incomingAction: Action): UserState => {
    if (state === undefined) {
        return { isLoggedIn: false };
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
    case "RECEIVE_LOGIN":
        return { isLoggedIn: action.isLoggedIn };
    default:
        return state;
    }
};
