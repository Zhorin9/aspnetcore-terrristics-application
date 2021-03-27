<template>
    <div :style="{padding: '20px'}">
        <div class="filter-container">
            <el-button
                class="filter-item"
                type="primary"
                icon="el-icon-plus"
                @click="handleCreate">
                Add new
            </el-button>
        </div>

        <el-row type="flex" class="row-bg" justify="center">

            <el-col :span="6" v-for="(o, index) in 3" :key="o" :offset="index > 0 ? 2 : 0">
                <el-card class="box-card">
                    <div slot="header" class="clearfix" align="left">
                        <span>Card name</span>
                        <el-button size="mini" type="primary" class="align-right-button"
                                   icon="el-icon-edit"></el-button>
                        <el-button size="mini" type="danger" class="align-right-button"
                                   icon="el-icon-delete"></el-button>
                    </div>
                    <div v-for="o in 4" :key="o" class="text item">
                        {{ 'List item ' + o }}
                    </div>
                </el-card>
            </el-col>
        </el-row>

        <sensor-form-dialog :key="`terrarium-form-dialog-key-${sensorFormDialogKey}`"
                            :is-create-modal="isCreateDialogForm"
                            :dialog-form-visible="dialogFormVisible"
                            :sensor-data="tempSensorFormData"
                            @operation-success="updateSensors"
                            @refresh-dialog="refreshDialog"/>
    </div>
</template>

<script lang="ts">
import {Component, Prop} from "vue-property-decorator";
import BackendOperationMixin from "@/mixins/backend-operation-mixin";
import SensorFormDialog from "@/views/sensors/components/SensorFormDialog.vue";
import {SensorModule} from "@/store/modules/sensor-module";
import {sensorTypes} from "@/utils/enums";
import {DictionaryModule} from "@/store/modules/dictionary-module";

@Component({
    name: 'Sensor',
    components: {SensorFormDialog}
})
export default class extends BackendOperationMixin {
    @Prop() windowId!: number;

    private sensorFormDialogKey: number = 0;

    private isCreateDialogForm: boolean = true;
    private dialogFormVisible: boolean = false;
    private tempSensorFormData: SensorFormDialogModel | null = null;

    get sensorBlocks() {
        return SensorModule.sensors;
    }

    created() {
        DictionaryModule.DICT_GET_ALL_SENSOR_KINDS();
        SensorModule.GET_LIST(this.windowId);
    }

    private handleCreate() {
        this.isCreateDialogForm = true;
        this.tempSensorFormData = {
            id: -1,
            name: '',
            description: '',
            windowId: this.windowId,
            type: sensorTypes.input,
            kindId: null,
        };
        this.dialogFormVisible = true;
    }

    private handleUpdate(row: any) {
        this.isCreateDialogForm = false;
        this.tempSensorFormData = Object.assign({}, row);
        this.dialogFormVisible = true;
    }

    private updateSensors(sensorId: number){
        this.refreshDialog();

        SensorModule.GET(sensorId);
        this.showNotification("Updated list", "Updated sensors list");
    }

    private refreshDialog(){
        this.dialogFormVisible = false;
        this.sensorFormDialogKey += 1;
    }

}
</script>

<style>
.align-right-button {
    float: right;
    margin-right: 2px;
}
</style>
