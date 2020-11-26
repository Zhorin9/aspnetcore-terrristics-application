<template>
    <div :style="{padding: '20px'}">
        <el-row type="flex" class="row-bg" justify="center">
            <el-col :span="6" v-for="(o, index) in 3" :key="o" :offset="index > 0 ? 2 : 0">
                <el-card :body-style="{ padding: '0px' }" shadow="never">
                    <img src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png" class="image">
                    <div style="padding: 14px;">
                        <span>Yummy hamburger</span>
                        <div class="bottom clearfix">
                            <time class="time">{{ currentDate }}</time>
                            <el-button type="text" class="button">Operating</el-button>
                        </div>
                    </div>
                </el-card>
            </el-col>
        </el-row>
    </div>
</template>

<script>
export default {
    name: "index"
}
</script>

<!--<style>-->
<!--.time {-->
<!--    font-size: 13px;-->
<!--    color: #999;-->
<!--}-->

<!--.bottom {-->
<!--    margin-top: 13px;-->
<!--    line-height: 12px;-->
<!--}-->

<!--.button {-->
<!--    padding: 0;-->
<!--    float: right;-->
<!--}-->

<!--.image {-->
<!--    width: 100%;-->
<!--    display: block;-->
<!--}-->

<!--.clearfix:before,-->
<!--.clearfix:after {-->
<!--    display: table;-->
<!--    content: "";-->
<!--}-->

<!--.clearfix:after {-->
<!--    clear: both-->
<!--}-->
<!--</style>-->
