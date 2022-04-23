import pg from 'pg';
import dotenv from 'dotenv';
const {Pool}=pg;
dotenv.config();
const env=process.env;
const pool = new Pool({
    user: env.user,
    database: env.database,
    password: env.password,
    port: env.port,
    host: env.host,
});

async function getExchanges(){
    console.log(env.password);
    const {rows} = await pool.query("select * from exchanges");
    return rows;
}
async function insertWillList(title,itemId,exchangeId){
    try{
        const res = await pool.query("insert into will_lists(item_id,exchange_id,title)values($1,$2,$3)",[itemId,exchangeId,title]);
        console.log(res);
    }catch(error){
        console.log(error);
    }
}
async function itemExist(exchangeId,itemId){
    const {rows} = await pool.query("select count(id) from will_lists where item_id=$1 and exchange_id=$2",[itemId,exchangeId]);
    return rows;
}
export const dbService={
    itemExist,insertWillList,getExchanges
}