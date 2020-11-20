<!--<template>-->
<!--    <el-dialog-->
<!--        :title="textMap[dialogStatus]"-->
<!--        :visible.sync="dialogFormVisible">-->
<!--        <validation-observer ref="observer" v-slot="{ invalid }">-->
<!--            <el-form-->
<!--                ref="dataForm"-->
<!--                :model="terrarium"-->
<!--                label-position="left"-->
<!--                label-width="100px"-->
<!--                style="width: 400px; margin-left:50px;">-->
<!--                <el-form-item-->
<!--                    :label="Name"-->
<!--                    prop="name">-->
<!--                    <el-input v-model="terrariumData.name"/>-->
<!--                </el-form-item>-->
<!--                <el-form-item :label="$t('table.status')">-->
<!--                    <el-select-->
<!--                        v-model="tempArticleData.status"-->
<!--                        class="filter-item"-->
<!--                        placeholder="Please select">-->
<!--                        <el-option-->
<!--                            v-for="item in statusOptions"-->
<!--                            :key="item"-->
<!--                            :label="item"-->
<!--                            :value="item"/>-->
<!--                    </el-select>-->
<!--                </el-form-item>-->
<!--                <el-form-item :label="$t('table.importance')">-->
<!--                    <el-rate-->
<!--                        v-model="tempArticleData.importance"-->
<!--                        :colors="['#99A9BF', '#F7BA2A', '#FF9900']"-->
<!--                        :max="3"-->
<!--                        style="margin-top:8px;"-->
<!--                    />-->
<!--                </el-form-item>-->
<!--                <el-form-item :label="$t('table.remark')">-->
<!--                    <el-input-->
<!--                        v-model="tempArticleData.abstractContent"-->
<!--                        :autosize="{minRows: 2, maxRows: 4}"-->
<!--                        type="textarea"-->
<!--                        placeholder="Please input"-->
<!--                    />-->
<!--                </el-form-item>-->
<!--            </el-form>-->
<!--            <div-->
<!--                slot="footer"-->
<!--                class="dialog-footer"-->
<!--            >-->
<!--                <el-button @click="dialogFormVisible = false">-->
<!--                    {{ $t('table.cancel') }}-->
<!--                </el-button>-->
<!--                <el-button-->
<!--                    type="primary"-->
<!--                    @click="dialogStatus==='create'?createData():updateData()"-->
<!--                >-->
<!--                    {{ $t('table.confirm') }}-->
<!--                </el-button>-->
<!--            </div>-->
<!--    </el-dialog>-->
<!--</template>-->

<script lang="ts">

import {Component, Prop} from "vue-property-decorator";
import BackendOperationMixin from "@/mixins/backend-operation-mixin";

@Component
export default class TerrariumEditDialog extends BackendOperationMixin {
    @Prop() selectedSensorBlock!: SensorBlockModel;
}
</script>
