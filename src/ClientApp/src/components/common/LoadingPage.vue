<template>
    <i :class="['fas fa-circle-notch fa-spin', sizeClass]"></i>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";

    @Component
    export default class LoadingPage extends Vue {
        @Prop({default: 1}) size!: number | undefined;

        get sizeClass() {
            return 'fa-' + this.size + 'x';
        }
    }
</script>