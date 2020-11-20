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
            :default-sort="{prop: 'date', order: 'descending'}"
            border
            fit
            highlight-current-row>
            <el-table-column
                align="center"
                label="ID"
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
                sortable
                width="140"
                align="center">
                <template slot-scope="scope">
                    {{ scope.row.creationDate | moment("YYYY-MM-DD") }}
                </template>
            </el-table-column>
            <el-table-column
                label="Modification date"
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
                        v-if="row.status!=='deleted'"
                        type="danger"
                        size="mini"
                        @click="handleDelete(row, $index)">
                        Delete
                    </el-button>
                </template>
            </el-table-column>
        </el-table>

<!--        <edit-dialog />-->
    </div>
</template>

<script lang="ts">
import {Component} from "vue-property-decorator";
import {TerrariumModule} from "@/store/modules/terrarium-module";
import BackendOperationMixin from "@/mixins/backend-operation-mixin";
import EditDialog from "@/views/terrariums/components/EditDialog.vue";

@Component({
    name: 'Terrarium',
    components: {EditDialog}
})
export default class extends BackendOperationMixin {
    private dialogStatus = ''

    get terrariums() {
        return TerrariumModule.terrariums;
    }

    created() {
        if (this.terrariums) {
            this.getTerrariums();
        }
    }

    getTerrariums() {
        this.startOperation();
        TerrariumModule.GET_LIST()
            .then(() => {
                this.operationSuccess();
            })
            .catch(err => {
                console.error(err);
                this.operationFail();
            })
    }

    private handleRedirect(row: any) {
        this.$router.push('terrariumDetail', {params: {id: row.id}});
    }

    private handleCreate(){

    }

    private handleUpdate(row){
        this.tempTerrairumData = Object.assign({}, row);
        this.dialogStatus = 'update';
        this.dialogFormVisible = true;
    }

    private handleDelete(row: any, index: number) {
        this.$notify({
            title: 'Success',
            message: 'Delete Successfully',
            type: 'success',
            duration: 2000
        })
        this.list.splice(index, 1)
    }
}
</script>
