import { Action, Reducer } from "redux";
import { AppThunkAction } from "./";

export interface CustomerState {
    customer: Customer;
}

export interface Customer {
    customerId: string;
    ssn: string;
    name: string;
}

interface RequestCustomerAction {
    type: "REQUEST_CUSTOMER";
}

interface ReceiveCustomerAction {
    type: "RECEIVE_CUSTOMER";
    customer: Customer;
}

type KnownAction = RequestCustomerAction | ReceiveCustomerAction;

export const actionCreators = {
    requestAccounts: (): AppThunkAction<KnownAction> => (
        dispatch,
        getState
    ) => {
        fetch(`api/v1/Customers`)
            .then((response) => response.json() as Promise<Customer>)
            .then((data) => {
                dispatch({ type: "RECEIVE_CUSTOMER", customer: data });
            });
    },
};

const unloadedState: CustomerState = {
    customer: { customerId: "", name: "", ssn: "" },
};

export const reducer: Reducer<CustomerState> = (
    state: CustomerState | undefined,
    incomingAction: Action
): CustomerState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
    case "RECEIVE_CUSTOMER":
        return {
            customer: action.customer,
        };
        break;
    }

    return state;
};
