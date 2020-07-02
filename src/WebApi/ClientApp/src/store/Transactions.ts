import { Action, Reducer } from "redux";
import { AppThunkAction } from "./";

export interface TransactionsState {
    account: AccountDetails;
}

export interface AccountDetails {
    accountId: string;
    currentBalance: number;
    credits: Credit[];
    debits: Debit[];
}

export interface Credit {
    transactionId: string;
    amount: number;
    description: string;
    transactionDate: Date;
}

export interface Debit {
    transactionId: string;
    amount: number;
    description: string;
    transactionDate: Date;
}

interface RequestTransactionsAction {
    type: "REQUEST_TRANSACTIONS";
}

interface ReceiveTransactionsAction {
    type: "RECEIVE_TRANSACTIONS";
    transactionState: TransactionsState;
}

type KnownAction = RequestTransactionsAction | ReceiveTransactionsAction;

export const actionCreators = {
    requestTransactions: (accountId: string): AppThunkAction<KnownAction> => (
        dispatch,
        getState
    ) => {
        fetch(`api/v1/Accounts/${accountId}`)
            .then((response) => response.json() as Promise<TransactionsState>)
            .then((data) => {
                dispatch({
                    type: "RECEIVE_TRANSACTIONS",
                    transactionState: data,
                });
            });
    },
};

const unloadedState: TransactionsState = {
    account: { credits: [], debits: [], accountId: "", currentBalance: 0 },
};

export const reducer: Reducer<TransactionsState> = (
    state: TransactionsState | undefined,
    incomingAction: Action
): TransactionsState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
    case "RECEIVE_TRANSACTIONS":
        return action.transactionState;
        break;
    }

    return state;
};
