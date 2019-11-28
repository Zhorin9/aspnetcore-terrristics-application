<template>
    <div id="home-top" class="home-top-index">
        <div class="home-top-index-text">
            <h1 class="font-weight-bold">Zarządzaj swoim terraium</h1>
            Kotroluj stan swojego terrarium z dowolnego miejsca poprzez przeglądarkę
            internetową.
            <div>
                <form method="get">
                    <button class="btn mt-3">
                        Rozpocznij za darmo
                    </button>
                </form>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import {Component, Vue} from "vue-property-decorator";

    @Component
    export default class HomeView extends Vue {
    };
</script>

<style scoped>
    .home-top-index {
        background-image: url('../../assets/homeBackground.jpg');
        height: 700px;
        line-height: 400px;
        width: 100%;
        display: table;
        background-size: cover;
        text-align: center;
        color: #fff;
    }

    .home-top-index-text {
        display: inline-block;
        vertical-align: middle;
        line-height: normal;
    }

    .home-top-index-text button {
        background-color: #009c1f;
        border: #1e7d31 solid 1px;
        color: #fff;
        font-size: larger;
    }

    .home-top-index-text button:hover {
        color: rgba(255, 255, 255, .75);
    }

    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }
</style>
