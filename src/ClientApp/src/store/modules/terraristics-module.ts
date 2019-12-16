import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import store from "@/store";
import {terraristicsWindowApiImpl} from "@/api/terraristics-window-api";

export interface TerraristicsState {
    TerraristicsWindows: Array<TerraristicsWindow>;
}

@Module({dynamic: true, store, name: 'terraristicsModule'})
class Terraristics extends VuexModule implements TerraristicsState {
    TerraristicsWindows = Array(0);
    
    @Mutation
    public UPDATE_TERRARISTICS_WINDOWS(terraristicsWindows: Array<TerraristicsWindow>) {
        this.TerraristicsWindows = terraristicsWindows;
    }

    @Action
    public GET_LIST() {
        return terraristicsWindowApiImpl.getTerraristicsWindows()
            .then(response => {
                this.UPDATE_TERRARISTICS_WINDOWS(response.data.Value);
            })
            .catch(err => {
                console.error(err);
            });
    }
}

export const TerraristicsModule = getModule(Terraristics);