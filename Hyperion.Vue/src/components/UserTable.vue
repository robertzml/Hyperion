<template>
  <div id="user">
    <v-client-table :data="tableData" :columns="columns" :options="options"></v-client-table>
  </div>
</template>

<script>
import Vue from 'vue'
import axios from 'axios'
import {ServerTable, ClientTable, Event} from 'vue-tables-2'
import { apihost } from '../config.js'

Vue.use(ClientTable, {
    perPage: 10
})

export default {
    data () {
        return {
            columns: ['Id', 'UserName', 'MSISDN', 'OSType'],
            tableData: [],
            users: [],
            options: {
                sortable: ['UserName'],
                templates: {
                    OSType: function (h, row) {
                        return '<button :id="row.Id">' + row.OSType + '</button>'
                    }
                }
            }
        }
    },
    created: function () {
        var vm = this
        axios.get(apihost + 'user')
            .then(function (response) {
                console.log(response)
                vm.users = response
                vm.tableData = response.data
            })
    }
}
</script>
