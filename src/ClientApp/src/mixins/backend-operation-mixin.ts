import {Component, Vue} from "vue-property-decorator";

@Component
export default class BackendOperationMixin extends Vue {
    operationFailed: boolean = false;
    operationInProgress: boolean = false;

    startOperation() {
        this.operationInProgress = true;
    }

    operationSuccess() {
        this.operationFailed = false;
        this.operationInProgress = false;
    }

    operationFail(err: any = null) {
        this.operationFailed = true;
        this.operationInProgress = false;
        console.error(err);
    }
}
