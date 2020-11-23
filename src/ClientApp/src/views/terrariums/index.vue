<template>
    <div class="app-container">

        <div class="filter-container">
            <el-button
                class="filter-item"
                type="primary"
                icon="el-icon-plus"
                @click="handleCreate">
                Add new
            </el-button>
        </div>

        <el-table
            v-loading="operationInProgress"
            :data="terrariums"
            element-loading-text="Loading"
            :default-sort="{prop: 'creationDate', order: 'descending'}"
            border>
            <el-table-column
                align="center"
                label="ID"
                prop="id"
                width="60"
                sortable>
                <template slot-scope="scope">
                    {{ scope.row.id }}
                </template>
            </el-table-column>
            <el-table-column
                label="Name"
                align="center">
                <template slot-scope="scope">
                    <span>{{ scope.row.name }}</span>
                </template>
            </el-table-column>
            <el-table-column
                label="Description"
                align="center">
                <template slot-scope="scope">
                    <span>{{ scope.row.description }}</span>
                </template>
            </el-table-column>
            <el-table-column
                label="Creation date"
                prop="creationDate"
                sortable
                width="140"
                align="center">
                <template slot-scope="scope">
                    {{ scope.row.creationDate | moment("YYYY-MM-DD") }}
                </template>
            </el-table-column>
            <el-table-column
                label="Modification date"
                prop="modificationDate"
                sortable
                width="180"
                align="center">
                <template slot-scope="scope">
                    {{ scope.row.modificationDate | moment("YYYY-MM-DD") }}
                </template>
            </el-table-column>
            <el-table-column
                label="ApiKey"
                class-name="status-col"
                width="300"
                align="center">
                <template slot-scope="scope">
                    <el-tag :type="scope.row.apiKey">
                        {{ scope.row.apiKey }}
                    </el-tag>
                </template>
            </el-table-column>
            <el-table-column
                label="Actions"
                align="center"
                width="300"
                class-name="fixed-width">
                <template slot-scope="{row, $index}">
                    <el-button
                        size="mini"
                        @click="handleRedirect(row)">
                        Redirect
                    </el-button>
                    <el-button
                        type="primary"
                        size="mini"
                        @click="handleUpdate(row)">
                        Edit row
                    </el-button>
                    <el-button
                        type="danger"
                        size="mini"
                        @click="handleDelete(row, $index)">
                        Delete
                    </el-button>
                </template>
            </el-table-column>
        </el-table>

        <terrarium-form-dialog :key="`terrarium-form-dialog-key-${terrariumFormDialogKey}`"
                               :terrarium-data="tempTerrariumFormData"
                               :is-create-modal="isCreateDialogForm"
                               :dialog-form-visible="dialogFormVisible"
                               @refresh-dialog="refreshDialog"
                               @operation-success="refreshDialogAndUpdateTerrariumList"/>
    </div>
</template>

<script lang="ts">
import {Component} from "vue-property-decorator";
import {TerrariumModule} from "@/store/modules/terrarium-module";
import BackendOperationMixin from "@/mixins/backend-operation-mixin";
import TerrariumFormDialog from "@/views/terrariums/components/TerrariumFormDialog.vue";

@Component({
    name: 'Terrarium',
    components: {TerrariumFormDialog}
})
export default class extends BackendOperationMixin {
    private terrariumFormDialogKey: number = 0;

    private isCreateDialogForm: boolean = true;
    private dialogFormVisible: boolean = false;
    private tempTerrariumFormData: TerrariumFormDialogModel | null = null;

    get terrariums() {
        return TerrariumModule.terrariums;
    }

    async created() {
        if (this.terrariums) {
            await this.getTerrariums();
        }
    }

    async getTerrariums() {
        this.startOperation();
        await TerrariumModule.GetList()
            .then(() => {
                this.operationSuccess();
            })
            .catch(err => {
                console.error(err);
                this.operationFail();
            })
    }

    private handleRedirect(row: any) {
        this.$router.push({name: 'terrarium', params: {id: row.id}});
    }

    private handleCreate() {
        this.isCreateDialogForm = true;
        this.tempTerrariumFormData = {
            id: -1,
            name: '',
            description: '',
            isPublic: false
        };
        this.dialogFormVisible = true;
    }

    private handleUpdate(row: any) {
        this.isCreateDialogForm = false;
        this.tempTerrariumFormData = Object.assign({}, row);
        this.dialogFormVisible = true;
    }

    private handleDelete(row: any, index: number) {
        TerrariumModule.DeleteTerrarium(row.id)
            .then(() => {
                this.$notify({
                    title: 'Success',
                    message: 'Delete Successfully',
                    type: 'success',
                    duration: 2000
                })
            })
            .catch(err => {
                console.error(err);
            })
    }

    private refreshDialog() {
        this.dialogFormVisible = false;
        this.terrariumFormDialogKey += 1;
        this.tempTerrariumFormData = null;
    }

    private refreshDialogAndUpdateTerrariumList() {
        this.refreshDialog();
        this.getTerrariums();
    }
}
</script>
