import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import store from "@/store";
import {terrariumApiImpl} from "@/api/terraristics-window-api";

export interface TerrariumState {
    terrariums: Array<TerrariumModel>;
}

@Module({dynamic: true, store, name: 'terraristicsModule'})
class Terrarium extends VuexModule implements TerrariumState {
    terrariums = Array(0);

    @Mutation
    public UPDATE_TERRARIUM_LIST(terrariums: Array<TerrariumModel>) {
        this.terrariums = terrariums;
    }

    @Action
    public GET_LIST() {
        return terrariumApiImpl.getList()
            .then(response => {
                this.UPDATE_TERRARIUM_LIST(response.data.terrariums);
                return true;
            })
            .catch(err => {
                console.error(err);
            });
    }

    @Action
    public UPDATE_TERRARIUM(terrariumData: TerraristiumFormData) {
        return terrariumApiImpl.update(terrariumData)
            .then(() => {
                return true;
            })
            .catch(err => {
                console.error(err);
            })
    }

    @Action
    public DELETE_TERRARIUM(terrariumId: number) {
        return terrariumApiImpl.delete(terrariumId)
            .then(() => {
                return true;
            })
            .catch(err => {
                console.error(err);
            })
    }
}

export const TerrariumModule = getModule(Terrarium);
