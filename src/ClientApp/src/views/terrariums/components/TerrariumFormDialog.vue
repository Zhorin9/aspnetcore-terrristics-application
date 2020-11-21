<template>
    <el-dialog
        :title="dialogTitle"
        :visible.sync="dialogFormVisible">
        <validation-observer ref="observer" v-slot="{ invalid }">
            <el-form
                ref="dataForm"
                :model="terrariumData"
                label-position="left"
                label-width="100px"
                style="width: 400px; margin-left:50px;">

                <validation-provider name="name" rules="required|min:3|max:30" v-slot="{ errors }">
                    <el-form-item prop="name" label="Name" :error="errors[0]">
                        <el-input v-model="terrariumData.name"/>
                    </el-form-item>
                </validation-provider>

                <validation-provider name="description" rules="max:200" v-slot="{ errors }">
                    <el-form-item label="Description" :error="errors[0]">
                        <el-input v-model="terrariumData.description"/>
                    </el-form-item>
                </validation-provider>

                <el-form-item label="Is public">
                    <el-checkbox v-model="terrariumData.isPublic"/>
                </el-form-item>

            </el-form>
        </validation-observer>
        <div
            slot="footer"
            class="dialog-footer">
            <el-button @click="dialogFormVisible = false">
                Cancel
            </el-button>
            <el-button
                type="primary"
                @click="isCreateModal ? handleCreate() : hadleUpdate()">
                Confirm
            </el-button>
        </div>
    </el-dialog>
</template>

<script lang="ts">

import {Component, Prop} from "vue-property-decorator";
import BackendOperationMixin from "@/mixins/backend-operation-mixin";

@Component({
    name: 'TerrariumFormDialog'
})
export default class TerrariumFormDialog extends BackendOperationMixin {
    @Prop() isCreateModal!: boolean;
    @Prop({default: {name: '', description: '', isPublic: ''}}) terrariumData!: TerrariumFormDialogModel;
    @Prop() dialogFormVisible!: boolean;

    private textMap = {
        update: 'Edit',
        create: 'Create'
    }

    get dialogTitle(){
        return this.isCreateModal ? 'Create' : 'Update';
    }

    handleCreate() {

    }

    handleUpdate() {

    }
}
</script>
