import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import store from "@/store";
import {DictionaryState} from "@/store/modules/dictionary-module";

export interface IAlertState {
    FailedLogin: any;
}

@Module({dynamic: true, store, name: 'alertModule'})
class Alert extends VuexModule implements IAlertState {
    public FailedLogin = {};

    @Mutation
    public ALERT_FAILED_LOGIN() {
        this.FailedLogin = true;
    }

    @Mutation
    public ALERT_SUCCESS_LOGIN() {
        this.FailedLogin = false;
    }
    
    //TODO extend alert module
    // @Action
}

export const AlertModule = getModule(Alert);