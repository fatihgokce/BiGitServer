import puppeteer from 'puppeteer';
import {dbService} from './db.js';
import { Exchanges } from './constants.js';
import axios from 'axios';
async function getTokoPedia(){
    const browser = await puppeteer.launch({ headless: false }); // for test disable the headlels mode,
    const page = await browser.newPage();
    await page.setViewport({ width: 1000, height: 926 });
    await page.goto("https://www.binance.com/en/support/announcement/c-48",{waitUntil: 'networkidle2'});

    console.log("start evaluate javascript")
    /** @type {string[]} */
    var productNames = await page.evaluate(()=>{
        // var div = document.querySelectorAll('.search-result-gridview-item');        
        // console.log(div) // console.log inside evaluate, will show on browser console not on node console
        
        // var productnames = [] 
        // div.forEach(element => { 
        //     var titleelem = element.querySelector('[data-type="itemTitles"]');
        //     if(titleelem != null){
        //         productnames.push(titleelem.textContent);
        //     }
        // });
        let c=document.querySelectorAll(".css-1q4wrpt .css-k5e9j4 a div")
        var names = [] 
        c.forEach(element => { 
            names.push(element.innerText);
        });
        return names
    })

    console.log(productNames)
    browser.close()
} 


//getTokoPedia();
async function checkBinance(){
    let rows = await dbService.getExchanges();
    const link="https://www.binance.com/bapi/composite/v1/public/cms/article/list/query?type=1&pageSize=20&pageNo=1";
    const pattern="Binance Will List".toLowerCase();
    try{
        const res = await axios.get(link);
        let lists = res.data.data.catalogs[0].articles;
        for (const item of lists) {
            
            if(item.title.toLowerCase().includes(pattern)){
                const exist = await dbService.itemExist(Exchanges.Binance,item.id);
                const is_exist = parseInt(exist[0].count) > 0;
                if(!is_exist){                                   
                    await Promise.all([sendMessageToTelegram(item.title),dbService.insertWillList(item.title,item.id,Exchanges.Binance)]);                    
                }
            }
        }
    }catch(error){
        console.log("error when get binance "+error);
    }

    // console.time(`process`);
    // console.log("some call:"+new Date())
    // console.timeEnd(`process`);
}
async function sendMessageToTelegram(message){
    const link="https://api.telegram.org/bot5298522617:AAFD8DJiWx7VyPPcNUg4AoFBeiv0-Zp8uww/sendMessage";
    try{
        const res = await axios.post(link,{
            chat_id:'-665035568',
            text:message
        })
    }catch(error){
        console.log(error);
    }
}
async function anotherCall(){
    // console.time(`process2`);
    // console.log("another call:"+new Date())
    // console.timeEnd(`process2`);
}
async function main(){
    while(true){
        await Promise.all([checkBinance(), anotherCall()]);       
        break;
    }
    console.log("finished");
}
main();