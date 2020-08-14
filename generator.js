function click(){
    let table = document.getElementById("generator_table")
    table.onclick = function(e){
        let element = e.target
        if(element.style.backgroundColor == "" || element.style.backgroundColor == "transparent"){
            element.style.backgroundColor = "deeppink"
        }else{
            element.style.backgroundColor = "transparent"
        }

        let data = []
        for(let i = 0; i < 16; i++){
            data[i] = 0
            for(let j = 0; j < 24; j++){
                data[i] <<= 1
                let e = document.getElementById(`table_${i}_${j}`)
                if(e.style.backgroundColor == "deeppink"){
                    data[i] |= 1
                }
            }
        }
        document.getElementById("data").innerText = data
    }
}
click()