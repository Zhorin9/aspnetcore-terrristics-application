<template>
    <el-dialog :title="dialogTitle"
               :visible="dialogFormVisible"
               @close="closeDialog"
               v-on:update:visible="closeDialog">
        <validation-observer ref="observer" v-slot="{ invalid }">
            <el-form
                ref="dataForm"
                :model="sensorData"
                label-position="left"
                label-width="auto"
                size="small"
                style="width: 400px; margin-left:50px;">

                <validation-provider name="name" rules="required|min:3|max:30" v-slot="{ errors }">
                    <el-form-item label="Name" :error="errors[0]">
                        <el-input v-model="sensorData.name"
                                  suffix-icon="el-icon-edit"/>
                    </el-form-item>
                </validation-provider>

                <validation-provider name="description" rules="max:200" v-slot="{ errors }">
                    <el-form-item label="Description" :error="errors[0]">
                        <el-input v-model="sensorData.description"
                                  type="textarea"/>
                    </el-form-item>
                </validation-provider>

                <validation-provider name="sensorType" rules="required" v-slot="{ errors }">
                    <el-form-item label="Sensor Type" :error="errors[0]">
                        <el-radio-group v-model="sensorType">
                            <el-radio v-for="sensorType in sensorTypes"
                                      :key='`sensor-type-radio-${sensorType.id}`'
                                      :label="sensorType.id">
                                {{sensorType.name}}
                            </el-radio>
                        </el-radio-group>
                    </el-form-item>
                </validation-provider>

                <validation-provider name="sensorKind" rules="required" v-slot="{ errors }">
                    <el-form-item label="Sensor Kind" :error="errors[0]">
                        <el-select v-model="sensorData.sensorKindId" placeholder="please select sensor kind">
                            <el-tooltip v-for="sensorKind in sensorKinds"
                                        class="item" effect="dark" :content="sensorKind.description" placement="left">
                                <el-option
                                           :key="`sensor-kind-${sensorKind.sensorKindId}`"
                                           :label="`${sensorKind.name} - ${sensorKind.shortDescription}`" :value="sensorKind.sensorKindId"/>
                            </el-tooltip>
                        </el-select>
                    </el-form-item>
                </validation-provider>

            </el-form>
        </validation-observer>
        <div slot="footer"
             class="dialog-footer">
            <el-button @click="closeDialog">
                Cancel
            </el-button>
            <el-button
                type="primary"
                :loading="operationInProgress"
                @click="handleSubmit">
                Submit
            </el-button>
        </div>
    </el-dialog>
</template>

<script lang="ts">
import {Prop} from "vue-property-decorator";
import Component from "vue-class-component";
import BackendOperationMixin from "@/mixins/backend-operation-mixin";
import {sensorTypes} from "@/utils/enums";
import {DictionaryModule} from "@/store/modules/dictionary-module";
import {sensorServiceImpl} from "@/services/sensor-service";

@Component({
    name: "SensorFormDialog"
})
export default class SensorFormDialog extends BackendOperationMixin {
    @Prop({required: true}) isCreateModal!: boolean;
    @Prop({required: true, default: {name: '', description: '', isPublic: ''}}) sensorData!: SensorFormDialogModel;
    @Prop({required: true}) dialogFormVisible!: boolean;
    visibleSync: boolean = this.dialogFormVisible;

    get dialogTitle() {
        return this.isCreateModal ? 'Add new sensor' : 'Update sensor';
    }

    get sensorTypes(){
        return sensorTypes.getSensorTypesWithName();
    }

    get sensorKinds(){
        if(this.sensorData.type == sensorTypes.read){
            return DictionaryModule.DICT_GET_INPUT_SENSORS;
        }

        return DictionaryModule.DICT_GET_OUTPUT_SENSORS;
    }

    get sensorType() {
        return this.sensorData.type;
    }
    set sensorType(value){
        this.sensorData.type = value;
        this.sensorData.sensorKindId = null;
    }

    private handleSubmit() {
        if (this.isCreateModal) {
            this.handleCreate();
        } else {
            this.handleUpdate();
        }
    }

    private async handleCreate() {
        //@ts-ignore
        const isValid = await this.$refs.observer.validate();
        if (!isValid) {
            return;
        }

        this.startOperation();
        sensorServiceImpl.create(this.sensorData)
            .then(sensorId => {
                this.showSuccessNotification();
                this.emitOperationSuccess(sensorId);
            })
            .catch(() => {
                this.operationFail();
                this.showFailedNotification();
            })
    }

    private async handleUpdate() {
        //@ts-ignore
        const isValid = await this.$refs.observer.validate();
        if (!isValid) {
            return;
        }

        this.startOperation();
        sensorServiceImpl.update(this.sensorData)
            .then(response => {
                this.emitOperationSuccess(response.data);
            })
            .catch(err => {
                console.error(err);
                this.operationFail();
            })
    }


    private closeDialog() {
        this.$emit('refresh-dialog');
    }

    private emitOperationSuccess(sensorId: number) {
        this.$emit('operation-success', sensorId);
    }
}
</script>
