import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import store from "@/store";
import _ from 'lodash';
import {terrariumApiImpl} from "@/api/terraristics-window-api";

export interface TerrariumState {
    terrariums: Array<TerrariumModel>;
}

@Module({dynamic: true, store, name: 'terrariumModule'})
class Terrarium extends VuexModule implements TerrariumState {
    terrariums = Array(0);

    @Mutation
    public UPDATE_TERRARIUM_LIST(terrariums: Array<TerrariumModel>) {
        this.terrariums = terrariums;
    }

    @Mutation
    public DELETE_TERRARIUM(id: Number) {
        let index = _.findIndex(this.terrariums, {'id': id});
        this.terrariums.splice(index, 1);
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
    public async UpdateTerrarium(terrariumData: TerrariumFormDialogModel) {
        return await terrariumApiImpl.update(terrariumData)
            .then(() => {
                return true;
            })
            .catch(err => {
                console.error(err);
            })
    }

    @Action
    public async DeleteTerrarium(terrariumId: number) {
        return await terrariumApiImpl.delete(terrariumId)
            .then(response => {
                this.DELETE_TERRARIUM(response.data);
                return true;
            })
            .catch(err => {
                console.error(err);
            })
    }
}

export const TerrariumModule = getModule(Terrarium);
