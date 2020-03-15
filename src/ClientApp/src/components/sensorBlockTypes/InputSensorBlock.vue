<script lang="ts">
    import {Line} from 'vue-chartjs'
    import {Component, Prop, Vue} from "vue-property-decorator";
    import {sensorBlockDataApiImpl} from "@/api/sensor-block-data-api";

    @Component({
        extends: Line,
    })
    export default class InputSensorBlock extends Vue {
        @Prop({default: null}) sensorBlockId!: number;

        public renderChart!: (chartData: any, options: any) => void;
        chartData: any = {
            labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
            datasets: [
                {
                    label: 'GitHub Commits',
                    backgroundColor: '#3f5741',
                    data: [40, 20, 12, 39, 10, 40, 39, 80, 40, null, 10, 25]
                }
            ]
        };
        chartOptions: any = {
            responsive: true,
            maintainAspectRatio: false
        };
        
        _getData(){
            sensorBlockDataApiImpl.getData(this.sensorBlockId);
        }

        mounted() {
            this.renderChart(this.chartData, this.chartOptions);
        }
    }
</script>