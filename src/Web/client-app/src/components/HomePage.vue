<template>
  <div class="hello">
    <div id="home-top" class="home-top-index">
        <div class="home-top-index-text">
            <h1 class="font-weight-bold">Zarządzaj swoim terraium</h1>
            Kotroluj stan swojego terrarium z dowolnego miejsca poprzez przeglądarkę internetową.
            <div>
                <form method="get">
                    <button class="btn mt-3">
                        Rozpocznij za darmo
                    </button>
                </form>
            </div>
        </div>
    </div>
  </div>
</template>

<script>

export default {
  name: 'HomePage',
  props: {
    msg: String,
  },
  //Metoda uruchamiana na starcie
  //lifecycle hooks
  created(){
    console.log("Dupa");
  },
  //poza importem musimy dodać components wraz z określonym
  //child componentem 
  components:{
    
  }
};
</script>

<style scoped>
.home-top-index {
    background-image: url('../assets/homeBackground.jpg');
    /* background-color: #1e7d31; */
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
            color: rgba(255,255,255,.75);
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
