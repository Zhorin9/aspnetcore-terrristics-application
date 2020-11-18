<template>
  <div class="login-container">
    <validation-observer ref="observer" v-slot="{ invalid }">
      <el-form
          ref="loginForm"
          class="login-form"
          autocomplete="on"
          label-position="left">
        <div class="title-container">
          <h3 class="title">
            Zaloguj się
          </h3>
        </div>

        <validation-provider name="email" rules="required|email" v-slot="{ errors }">
          <el-form-item prop="email" :error="errors[0]">
        <span class="svg-container">
          <svg-icon name="user"/>
        </span>
            <el-input
                ref="email"
                v-model="email"
                name="email"
                type="text"
                autocomplete="on"
                placeholder="Email"/>
          </el-form-item>
        </validation-provider>

        <validation-provider name="password" rules="required|min:6" v-slot="{ errors }">
          <el-form-item prop="password" :error="errors[0]">
        <span class="svg-container">
          <svg-icon name="password"/>
        </span>
            <el-input
                :key="passwordType"
                ref="password"
                v-model="password"
                :type="passwordType"
                placeholder="password"
                name="password"
                autocomplete="on"
                @keyup.enter.native="handleLogin"/>
            <span
                class="show-pwd"
                @click="showPwd">
          <svg-icon :name="passwordType === 'password' ? 'eye-off' : 'eye-on'"/>
        </span>
          </el-form-item>
        </validation-provider>

        <el-button
            :loading="loading"
            type="primary"
            style="width:100%; margin-bottom:30px;"
            @click.native.prevent="handleLogin">
          Sign in
        </el-button>
      </el-form>
    </validation-observer>
  </div>
</template>

<script lang="ts">
import {Component, Vue, Watch} from 'vue-property-decorator'
import {Route} from 'vue-router'
import {Dictionary} from 'vue-router/types/router'
import {Input} from 'element-ui'
import {UserModule} from '@/store/modules/user'

@Component
export default class extends Vue {
  email: string = "";
  password: string = "";

  private passwordType = 'password'
  private loading = false
  private showDialog = false
  private redirect?: string
  private otherQuery: Dictionary<string> = {}

  @Watch('$route', {immediate: true})
  private onRouteChange(route: Route) {
    // TODO: remove the "as Dictionary<string>" hack after v4 release for vue-router
    const query = route.query as Dictionary<string>
    if (query) {
      this.redirect = query.redirect
      this.otherQuery = this.getOtherQuery(query)
    }
  }

  private showPwd() {
    if (this.passwordType === 'password') {
      this.passwordType = '';
    } else {
      this.passwordType = 'password';
    }
    this.$nextTick(() => {
      (this.$refs.password as Input).focus()
    });
  }

  private async handleLogin() {
    //@ts-ignore
    const isValid = await this.$refs.observer.validate();
    if (!isValid) {
      return;
    }
    const {email, password} = this;
    if (email && password) {
      await UserModule.Login({email: email, password: password});
      
      debugger;
      this.$router.push({
        path: this.redirect || '/',
        query: this.otherQuery
      })
    }
  }

  private getOtherQuery(query: Dictionary<string>) {
    return Object.keys(query).reduce((acc, cur) => {
      if (cur !== 'redirect') {
        acc[cur] = query[cur]
      }
      return acc
    }, {} as Dictionary<string>)
  }
}
</script>

<style lang="scss">
// References: https://www.zhangxinxu.com/wordpress/2018/01/css-caret-color-first-line/
@supports (-webkit-mask: none) and (not (cater-color: $loginCursorColor)) {
  .login-container .el-input {
    input {
      color: $loginCursorColor;
    }

    input::first-line {
      color: $lightGray;
    }
  }
}

.login-container {
  .el-input {
    display: inline-block;
    height: 47px;
    width: 85%;

    input {
      height: 47px;
      background: transparent;
      border: 0px;
      border-radius: 0px;
      padding: 12px 5px 12px 15px;
      color: $lightGray;
      caret-color: $loginCursorColor;
      -webkit-appearance: none;

      &:-webkit-autofill {
        box-shadow: 0 0 0px 1000px $loginBg inset !important;
        -webkit-text-fill-color: #fff !important;
      }
    }
  }

  .el-form-item {
    border: 1px solid rgba(255, 255, 255, 0.1);
    background: rgba(0, 0, 0, 0.1);
    border-radius: 5px;
    color: #454545;
  }
}
</style>

<style lang="scss" scoped>
.login-container {
  height: 100%;
  width: 100%;
  overflow: hidden;
  background-color: $loginBg;

  .login-form {
    position: relative;
    width: 520px;
    max-width: 100%;
    padding: 160px 35px 0;
    margin: 0 auto;
    overflow: hidden;
  }

  .tips {
    font-size: 14px;
    color: #fff;
    margin-bottom: 10px;

    span {
      &:first-of-type {
        margin-right: 16px;
      }
    }
  }

  .svg-container {
    padding: 6px 5px 6px 15px;
    color: $darkGray;
    vertical-align: middle;
    width: 30px;
    display: inline-block;
  }

  .title-container {
    position: relative;

    .title {
      font-size: 26px;
      color: $lightGray;
      margin: 0px auto 40px auto;
      text-align: center;
      font-weight: bold;
    }
  }

  .show-pwd {
    position: absolute;
    right: 10px;
    top: 7px;
    font-size: 16px;
    color: $darkGray;
    cursor: pointer;
    user-select: none;
  }
}
</style>
