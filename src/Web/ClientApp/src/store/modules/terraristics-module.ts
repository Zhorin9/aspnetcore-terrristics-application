import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import store from "@/store";
import {terraristicsWindowApiImpl} from "@/api/terraristics-window-api";

export interface TerraristicsState {
    TerraristicsWindows: Array<TerraristicsWindowModel>;
}

@Module({dynamic: true, store, name: 'terraristicsModule'})
class Terraristics extends VuexModule implements TerraristicsState {
    TerraristicsWindows = Array(0);

    @Mutation
    public UPDATE_TERRARISTICS_WINDOWS(terraristicsWindows: Array<TerraristicsWindowModel>) {
        this.TerraristicsWindows = terraristicsWindows;
    }

    @Action
    public GET_LIST() {
        return terraristicsWindowApiImpl.getList()
            .then(response => {
                this.UPDATE_TERRARISTICS_WINDOWS(response.data.Value);
                return true;
            })
            .catch(err => {
                console.error(err);
            });
    }

    @Action
    public UPDATE_WINDOW(windowData: TerraristicsWindowFormData) {
        return terraristicsWindowApiImpl.update(windowData)
            .then(() => {
                return true;
            })
            .catch(err => {
                console.error(err);
            })
    }

    @Action
    public DELETE_WINDOW(windowId: number) {
        return terraristicsWindowApiImpl.delete(windowId)
            .then(() => {
                return true;
            })
            .catch(err => {
                console.error(err);
            })
    }
}

export const TerraristicsModule = getModule(Terraristics);