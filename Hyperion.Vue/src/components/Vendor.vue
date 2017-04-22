<template>
    <div id="vendor">
        <!-- BEGIN PAGE HEAD-->
        <div class="page-head">
            <!-- BEGIN PAGE TITLE -->
            <div class="page-title">
                <h1>
                    {{ title }}
                    <small></small>
                </h1>
            </div>
            <!-- END PAGE TITLE -->
        </div>
        <!-- END PAGE HEAD-->
        <!-- BEGIN PAGE BREADCRUMB -->
        <ul class="page-breadcrumb breadcrumb">
            <li>
                <router-link :to="{ name: 'home' }">主页</router-link>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <a href="#">厂家管理</a>
                <i class="fa fa-circle"></i>
            </li>
            <li>
                <span class="active">{{ title }}</span>
            </li>
        </ul>
    
        <div class="row">
            <div class="col-md-12">
                <ol>
                    <li v-for="item in vendors">
                        {{ item.Name }}
                    </li>
                </ol>
                <table>
                    <tbody>
                        <tr v-for="item in vendors">
                            <td>{{ item.Name }}</td>
                            <td>{{ item.Description }}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    name: 'vendor',
    data () {
        return {
            title: '厂家列表',
            vendors: []
        }
    },
    created: function () {
        var vm = this
        axios.get('http://localhost:6024/api/vendorinfo')
            .then(function (response) {
                console.log(response)
                vm.vendors = response.data
        })
    }
}
</script>
