<template>
    <div>
        <line-chart v-if="showLineChart" :chart-data="mockedChartData"/>
        <loading-page v-else-if="showLoadingPage" :size="6"/>
        <error-page v-else :size="6"/>
    </div>
</template>
<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";
    import {sensorBlockDataApiImpl} from "@/api/sensor-block-data-api";
    import LineChart from "@/components/common/LineChart.vue";
    import _ from "lodash";

    @Component({
        components: {
            LineChart
        },
    })
    export default class InputSensorBlock extends Vue {
        @Prop({default: null}) sensorBlockId!: number;
        loadingData: boolean = true;
        showErrorPage: boolean = false;
        chartXData: Array<number> = [];
        chartYData: Array<Date> = [];

        get showLineChart() {
            return !this.loadingData && !this.showErrorPage;
        }

        get showLoadingPage() {
            return this.loadingData && !this.showErrorPage;
        }

        getData() {
            this.loadingData = true;
            sensorBlockDataApiImpl.getData(this.sensorBlockId)
                .then(response => {
                    this.loadingData = false;
                    _.each(response, point => {
                        this.chartXData.push(point.Value);
                        this.chartYData.push(point.CreationDate);
                    });
                })
                .catch(err => {
                    console.error(err);
                    this.showErrorPage = true;
                });
        }

        mounted() {
            this.getData();
        }

        mockedChartData: any = {
            labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
            datasets: [
                {
                    label: 'GitHub Commits',
                    backgroundColor: '#3f5741',
                    data: [40, 20, 12, 39, 10, 40, 39, 80, 40, null, 10, 25]
                }
            ]
        };
    }
</script>