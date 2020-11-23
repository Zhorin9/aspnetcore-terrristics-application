<template>
    <el-dialog :title="dialogTitle"
               :visible.sync="dialogFormVisible"
               @close="closeDialog">
        <validation-observer ref="observer" v-slot="{ invalid }">
            <el-form
                ref="dataForm"
                :model="terrariumData"
                label-position="left"
                label-width="100px"
                style="width: 400px; margin-left:50px;">

                <validation-provider name="name" rules="required|min:3|max:30" v-slot="{ errors }">
                    <el-form-item label="Name" :error="errors[0]">
                        <el-input v-model="terrariumData.name"
                                  suffix-icon="el-icon-edit"/>
                    </el-form-item>
                </validation-provider>

                <validation-provider name="description" rules="max:200" v-slot="{ errors }">
                    <el-form-item label="Description" :error="errors[0]">
                        <el-input v-model="terrariumData.description"
                                  type="textarea"/>
                    </el-form-item>
                </validation-provider>

                <el-form-item label="Is public">
                    <el-checkbox v-model="terrariumData.isPublic"/>
                </el-form-item>

            </el-form>
        </validation-observer>
        <div slot="footer"
             class="dialog-footer">
            <el-button @click="dialogFormVisible = false">
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

import {Component, Prop} from "vue-property-decorator";
import BackendOperationMixin from "@/mixins/backend-operation-mixin";
import {TerrariumModule} from "@/store/modules/terrarium-module";

@Component({
    name: 'TerrariumFormDialog'
})
export default class TerrariumFormDialog extends BackendOperationMixin {
    @Prop() isCreateModal!: boolean;
    @Prop({default: {name: '', description: '', isPublic: ''}}) terrariumData!: TerrariumFormDialogModel;
    @Prop() dialogFormVisible!: boolean;

    get dialogTitle() {
        return this.isCreateModal ? 'Add new terrarium' : 'Update terrarium';
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
        TerrariumModule.Create(this.terrariumData)
            .then(terrariumId => {
                this.emitOperationSuccess(terrariumId);
            })
            .catch(err => {
                console.error(err);
                this.operationFail();
            })
    }

    private async handleUpdate() {
        //@ts-ignore
        const isValid = await this.$refs.observer.validate();
        if (!isValid) {
            return;
        }

        this.startOperation();
        TerrariumModule.Update(this.terrariumData)
            .then(terrariumId => {
                this.emitOperationSuccess(terrariumId);
            })
            .catch(err => {
                console.error(err);
                this.operationFail();
            })
    }

    private closeDialog(){
        this.$emit('refresh-dialog');
    }

    private emitOperationSuccess() {
        this.$emit('operation-success');
    }
}
</script>
