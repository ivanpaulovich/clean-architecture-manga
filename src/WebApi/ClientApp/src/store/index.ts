import * as Counter from "./Counter";
import * as User from "./User";
import * as Accounts from "./Accounts";
import * as Transactions from "./Transactions";

// The top-level state object
export interface ApplicationState {
    counter: Counter.CounterState | undefined;
    user: User.UserState | undefined;
    accounts: Accounts.AccountsState | undefined;
    accountDetails: Transactions.TransactionsState | undefined;
}

// Whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
export const reducers = {
    counter: Counter.reducer,
    user: User.reducer,
    accounts: Accounts.reducer,
    accountDetails: Transactions.reducer,
};

// This type can be used as a hint on action creators so that its 'dispatch' and 'getState' params are
// correctly typed to match your store.
export interface AppThunkAction<TAction> {
    (
        dispatch: (action: TAction) => void,
        getState: () => ApplicationState
    ): void;
}
