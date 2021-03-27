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

    operationFail() {
        this.operationFailed = true;
        this.operationInProgress = false;
    }

    showNotification(title: string, message: string) {
        this.$notify({
            title: title,
            message: message
        })
    }

    showSuccessNotification(){
        this.$notify({
            title: 'Success',
            message: 'The operation was successful',
            type: 'success'
        });
    }

    showFailedNotification(){
        this.$notify({
            title: 'Error',
            message: 'The operation failed',
            type: 'error'
        });
    }
}
