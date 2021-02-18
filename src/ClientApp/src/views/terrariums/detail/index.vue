<template>
    <div :style="{padding: '20px'}">
        <el-row type="flex" class="row-bg" justify="center">

            <el-col :span="6" v-for="(o, index) in 3" :key="o" :offset="index > 0 ? 2 : 0">
                <el-card class="box-card">
                    <div slot="header" class="clearfix" align="left">
                        <span>Card name</span>
                        <el-button size="mini" type="primary" class="align-right-button" icon="el-icon-edit"></el-button>
                        <el-button size="mini" type="danger" class="align-right-button" icon="el-icon-delete"></el-button>
                    </div>
                    <div v-for="o in 4" :key="o" class="text item">
                        {{ 'List item ' + o }}
                    </div>
                </el-card>
            </el-col>
        </el-row>
    </div>
</template>

<script lang="ts">
import {Component, Prop} from "vue-property-decorator";
import BackendOperationMixin from "@/mixins/backend-operation-mixin";
import {SensorModule} from "@/store/modules/sensor-module";

@Component({
    name: 'TerrariumDetail'
})
export default class extends BackendOperationMixin {
    @Prop() id!: string;

    get sensorBlocks() {
        debugger;
        return SensorModule.sensors;
    }

    created() {
        SensorModule.GET_LIST(this.id);
    }
}
</script>

<style>
.align-right-button {
    float: right;
    margin-right: 2px;
}
</style>
