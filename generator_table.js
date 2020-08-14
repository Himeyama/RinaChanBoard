function generator_table(){
    let e = document.getElementById("generator_table")
    for(let i = 0; i < 16; i++){
        let tr = document.createElement("tr");
        for(let j = 0; j < 24; j++){
            let td = document.createElement("td")
            tr.append(td)
            td.id = `table_${i}_${j}`
        }
        e.append(tr)
    }
}
generator_table()