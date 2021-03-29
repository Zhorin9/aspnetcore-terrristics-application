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

        <div style="margin: 50px">
            <el-carousel type="card">
                <el-carousel-item v-for="(sensor, index) in sensors" :key="`sensor-carousel-${index}`">
                    <el-card class="box-card">
                        <div slot="header" class="clearfix" align="left">
                            <span>{{ sensor.name }}</span>
                            <el-button size="mini" type="primary"
                                       class="align-right-button"
                                       icon="el-icon-edit"/>
                            <el-button size="mini" type="danger"
                                       class="align-right-button"
                                       icon="el-icon-delete"/>
                        </div>
                        <div style="padding: 14px;">
                            <span>{{ sensor.description }}</span>
                            <div class="bottom clearfix">
                                <div class="bottom clearfix">
                                    <span>Sensor: {{ sensor.sensorKind.name }}</span>
                                    <br/>
                                    <time class="time">Created: {{ sensor.createdDate | moment("DD-MM-YYYY") }}</time>
                                </div>
                            </div>
                        </div>
                    </el-card>
                </el-carousel-item>
            </el-carousel>
        </div>

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
import {sensorTypes} from "@/utils/enums";
import {DictionaryModule} from "@/store/modules/dictionary-module";
import {sensorServiceImpl} from "@/services/sensor-service";
import _ from "lodash";

@Component({
    components: {SensorFormDialog}
})
export default class extends BackendOperationMixin {
    @Prop() windowId!: string;
    private sensors: Array<SensorModel> = [];

    private sensorFormDialogKey: number = 0;

    private isCreateDialogForm: boolean = true;
    private dialogFormVisible: boolean = false;
    private tempSensorFormData: SensorFormDialogModel | null = null;

    get sensorChunks() {
        return _.chunk(Object.values(this.sensors), 3);
    }

    get parsedWindowId() {
        return parseInt(this.windowId);
    }

    created() {
        DictionaryModule.DICT_GET_ALL_SENSOR_KINDS();
        sensorServiceImpl.getList(this.parsedWindowId)
            .then(sensors => {
                this.sensors = sensors;
            });
    }

    private handleCreate() {
        this.isCreateDialogForm = true;
        this.tempSensorFormData = {
            id: -1,
            name: '',
            description: '',
            windowId: this.parsedWindowId,
            type: sensorTypes.read,
            sensorKindId: null,
        };
        this.dialogFormVisible = true;
    }

    private handleUpdate(row: any) {
        this.isCreateDialogForm = false;
        this.tempSensorFormData = Object.assign({}, row);
        this.dialogFormVisible = true;
    }

    private updateSensors(sensorId: number) {
        this.refreshDialog();
        sensorServiceImpl.get(sensorId)
            .then(sensor => {
                this.sensors.push(sensor);
                this.showNotification("Updated list", "Updated sensors list");
            });
    }

    private refreshDialog() {
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

.time {
    font-size: 13px;
    color: #999;
}

.bottom {
    margin-top: 13px;
    line-height: 12px;
}

.button {
    padding: 0;
    float: right;
}

.image {
    width: 100%;
    display: block;
}

.clearfix:before,
.clearfix:after {
    display: table;
    content: "";
}

.clearfix:after {
    clear: both
}
</style>
