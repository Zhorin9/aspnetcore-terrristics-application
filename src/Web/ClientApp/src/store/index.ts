import Vue from 'vue';
import Vuex from 'vuex';
import {AppState} from './modules/app';
import {DictionaryState} from "@/store/modules/dictionary-module";
import {IAlertState} from "@/store/modules/alert-module";
import {AuthenticationState} from "@/store/modules/authentication-module";

Vue.use(Vuex);

export interface IRootState {
    app: AppState,
    authentication: AuthenticationState,
    dictionary: DictionaryState,
    alert: IAlertState,
}

// Declare empty store first, dynamically register all modules later.
export default new Vuex.Store<IRootState>({})
