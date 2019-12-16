import {Action, getModule, Module, Mutation, VuexModule} from "vuex-module-decorators";
import store from "@/store";

export interface SensorBlockState {
    SensorBlocks: Array<any>;
}

@Module({dynamic: true, store, name: 'terraristicsModule'})
class SensorBlock extends VuexModule implements SensorBlockState {
    SensorBlocks: Array<any> = Array(0);
    
}

export const SensorBlockModule = getModule(SensorBlock);