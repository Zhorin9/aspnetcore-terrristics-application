import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import store from "@/store";
import {DictionaryState} from "@/store/modules/dictionary-module";

export interface IAlertState {
    failedLogin: any;
}

@Module({dynamic: true, store, name: 'alertModule'})
class Alert extends VuexModule implements IAlertState {
    public failedLogin = {};

    @Mutation
    public ALERT_FAILED_LOGIN() {
        this.failedLogin = true;
    }

    @Mutation
    public ALERT_SUCCESS_LOGIN() {
        this.failedLogin = false;
    }
    
    //TODO extend alert module
    // @Action
}

export const AlertModule = getModule(Alert);