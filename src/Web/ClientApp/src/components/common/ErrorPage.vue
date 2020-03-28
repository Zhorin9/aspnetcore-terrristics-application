<template>
    <div>
        <i :class="['fas fa-exclamation-circle', sizeClass]"></i><br>
        <span>Nie udało się pobrać danych</span>
    </div>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";

    @Component
    export default class ErrorPage extends Vue {
        @Prop({default: 1}) size!: number | undefined;

        get sizeClass() {
            return 'fa-' + this.size + 'x';
        }
    }
</script>